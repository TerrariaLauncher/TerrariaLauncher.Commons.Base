using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.API.EndPoints.KeyValue.Queries;

namespace TerrariaLauncher.Commons.Consul.ConfigurationProvider
{
    public class ConsulConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider
    {
        HttpClient httpClient;
        ReadKeyQueryHandler readKeyQueryHandler;
        string key;

        public ConsulConfigurationProvider(ConsulHostConfiguration configs, string key)
        {
            this.httpClient = new HttpClient();
            this.readKeyQueryHandler = new ReadKeyQueryHandler();
            this.key = key;

            var schema = configs.UseTls ? "https" : "http";
            this.httpClient.BaseAddress = new Uri($"{schema}://{configs.Host}:{configs.Port}/v1/");
        }

        public override void Load()
        {
            this.LoadAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            var query = new ReadKeyQuery()
            {
                Recurse = true,
                Key = this.key
            };

            var result = await this.readKeyQueryHandler.Handle(this.httpClient, query, cancellationToken).ConfigureAwait(false);
            var utf8Encoding = new System.Text.UTF8Encoding();
            foreach (var metadata in result.Metadata)
            {
                var json = utf8Encoding.GetString(Convert.FromBase64String(metadata.Value));
                var options = Flatten(json);

                foreach (var option in options)
                {
                    base.Set(option.Key, option.Value.ToString());
                }
            }
        }

        private static IDictionary<string, JsonElement> Flatten(string json)
        {
            using (var document = JsonDocument.Parse(json))
            {
                var leaves = new List<(IImmutableList<string> Path, JsonElement Element)>();

                var candidates = new Stack<(IImmutableList<string> Path, JsonElement Element)>();
                candidates.Push((ImmutableList.Create<string>(), document.RootElement));

                while (candidates.Count > 0)
                {
                    var candidate = candidates.Pop();
                    switch (candidate.Element.ValueKind)
                    {
                        case JsonValueKind.Object:
                            foreach (var property in candidate.Element.EnumerateObject())
                            {
                                candidates.Push((candidate.Path.Add(property.Name), property.Value));
                            }
                            break;
                        case JsonValueKind.Array:
                            int index = 0;
                            foreach (var element in candidate.Element.EnumerateArray())
                            {
                                candidates.Push((candidate.Path.Add(index.ToString()), element));
                            }
                            break;
                        default:
                            leaves.Add((candidate.Path, candidate.Element));
                            break;
                    }
                }

                return leaves.ToDictionary(item => ConfigurationPath.Combine(item.Path), item => item.Element.Clone());
            }
        }
    }
}
