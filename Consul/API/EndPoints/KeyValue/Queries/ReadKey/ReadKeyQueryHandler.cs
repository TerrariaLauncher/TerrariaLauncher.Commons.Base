using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;
using TerrariaLauncher.Commons.Consul.API.DTOs;
using TerrariaLauncher.Commons.Extensions;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.KeyValue.Queries
{
    public class ReadKeyQueryHandler : ConsulQueryHandler<ReadKeyQuery, ReadKeyQueryResult>
    {
        protected override Task PrepareRequest(HttpRequestMessage httpRequestMessage, ReadKeyQuery query, CancellationToken cancellationToken = default)
        {
            var uriBuider = new UriBuilder(httpRequestMessage.RequestUri);
            uriBuider.Path += $"{query.Key}";
            if (!string.IsNullOrWhiteSpace(query.DataCenter))
            {
                uriBuider.AppendQuery("dc", query.DataCenter);
            }
            if (query.Recurse)
            {
                uriBuider.AppendQuery("recurse", "true");
            }
            httpRequestMessage.RequestUri = uriBuider.Uri;
            return Task.CompletedTask;
        }

        protected override async Task<ReadKeyQueryResult> ProcessResponse(HttpResponseMessage httpResponseMessage, ReadKeyQuery query, CancellationToken cancellationToken = default)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            var result = new ReadKeyQueryResult()
            {
                Metadata = await httpResponseMessage.Content.ReadFromJsonAsync<KeyValueMetadata[]>(cancellationToken: cancellationToken)
            };
            return result;
        }
    }
}
