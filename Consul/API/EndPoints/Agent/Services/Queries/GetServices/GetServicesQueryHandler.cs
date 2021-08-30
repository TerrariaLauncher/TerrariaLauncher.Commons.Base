using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.API.DTOs;
using TerrariaLauncher.Commons.Extensions;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetServicesQueryHandler : ConsulQueryHandler<GetServicesQuery, GetServicesQueryResult>
    {
        protected override Task PrepareRequest(HttpRequestMessage httpRequestMessage, GetServicesQuery query, CancellationToken cancellationToken = default)
        {
            var uriBuilder = new UriBuilder(httpRequestMessage.RequestUri);
            uriBuilder.AppendQuery("filter", query.Query.ToString());
            httpRequestMessage.RequestUri = uriBuilder.Uri;
            return Task.CompletedTask;
        }

        protected override async Task<GetServicesQueryResult> ProcessResponse(HttpResponseMessage httpResponseMessage, GetServicesQuery query, CancellationToken cancellationToken = default)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            return new GetServicesQueryResult()
            {
                Services = await httpResponseMessage.Content.ReadFromJsonAsync<IDictionary<string, RegisteredService>>(cancellationToken: cancellationToken)
            };
        }
    }
}
