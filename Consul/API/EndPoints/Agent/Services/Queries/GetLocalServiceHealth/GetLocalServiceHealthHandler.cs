using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetLocalServiceHealthHandler : ConsulQueryHandler<GetLocalServiceHealth, GetLocalServiceHealthResult>
    {
        protected override Task PrepareRequest(HttpRequestMessage httpRequestMessage, GetLocalServiceHealth query, CancellationToken cancellationToken = default)
        {
            var uriBuilder = new UriBuilder(httpRequestMessage.RequestUri);
            if (!string.IsNullOrWhiteSpace(query.Id))
            {
                uriBuilder.Path += $"id/{query.Id}";
            }
            else
            {
                uriBuilder.Path += $"name/{query.Name}";
            }

            httpRequestMessage.RequestUri = uriBuilder.Uri;
            return Task.CompletedTask;
        }

        protected override async Task<GetLocalServiceHealthResult> ProcessResponse(HttpResponseMessage httpResponseMessage, GetLocalServiceHealth query, CancellationToken cancellationToken = default)
        {
            var result = new GetLocalServiceHealthResult();
            switch ((int)httpResponseMessage.StatusCode)
            {
                case 200:
                    result.AggregateStatus = ServiceHealthStatus.Passing;
                    break;
                case 429:
                    result.AggregateStatus = ServiceHealthStatus.Warning;
                    break;
                case 503:
                    result.AggregateStatus = ServiceHealthStatus.Critical;
                    break;
                default:
                    httpResponseMessage.EnsureSuccessStatusCode();
                    break;
            }

            var jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions()
            {
                Converters =
                    {
                        new ServiceHealthStatusJsonConverter()
                    }
            };

            if (string.IsNullOrWhiteSpace(query.Id))
            {
                var single = await httpResponseMessage.Content.ReadFromJsonAsync<LocalServiceHealth>(jsonSerializerOptions, cancellationToken);
                result.Details = new LocalServiceHealth[] { single };
            }
            else
            {
                var multiple = await httpResponseMessage.Content.ReadFromJsonAsync<LocalServiceHealth[]>(jsonSerializerOptions, cancellationToken);
                result.Details = multiple;
            }

            return result;
        }
    }
}
