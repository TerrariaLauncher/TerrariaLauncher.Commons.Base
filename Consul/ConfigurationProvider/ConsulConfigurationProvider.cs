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
using TerrariaLauncher.Commons.Consul.API.EndPoints.KeyValue.Queries.Handlers;

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
            IEnumerable<(IImmutableList<string> path, JsonProperty property)> GetLeaves(IImmutableList<string> path, JsonProperty property)
            {
                if (path is null)
                {
                    path = ImmutableList.Create<string>(property.Name);
                }
                else
                {
                    path = path.Add(property.Name);
                }

                if (property.Value.ValueKind != JsonValueKind.Object)
                {
                    return new[] { (path: path, property) };
                }
                else
                {
                    return property.Value.EnumerateObject()
                        .SelectMany(child => GetLeaves(path: path, child));
                }
            }

            using (var document = JsonDocument.Parse(json))
            {
                return document.RootElement.EnumerateObject()
                    .SelectMany(property => GetLeaves(null, property))
                    .ToDictionary(item => ConfigurationPath.Combine(item.path), item => item.property.Value.Clone());
            }
        }
    }
}
