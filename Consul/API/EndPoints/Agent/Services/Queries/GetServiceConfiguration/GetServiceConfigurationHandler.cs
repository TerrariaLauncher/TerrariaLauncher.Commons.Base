using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries.GetServiceConfiguration
{
    public class GetServiceConfigurationHandler : ConsulQueryHandler<GetServiceConfigurationQuery, GetServiceConfigurationResult>
    {
        protected override Task PrepareRequest(HttpRequestMessage httpRequestMessage, GetServiceConfigurationQuery query, CancellationToken cancellationToken = default)
        {
            var uri = new UriBuilder(httpRequestMessage.RequestUri);
            uri.Path += $"{query.ServiceId}";
            httpRequestMessage.RequestUri = uri.Uri;
            return Task.CompletedTask;
        }

        protected override async Task<GetServiceConfigurationResult> ProcessResponse(HttpResponseMessage httpResponseMessage, GetServiceConfigurationQuery query, CancellationToken cancellationToken = default)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            return new GetServiceConfigurationResult()
            {
                Service = await httpResponseMessage.Content.ReadFromJsonAsync<RegisteredService>(cancellationToken: cancellationToken)
            };
        }
    }
}
