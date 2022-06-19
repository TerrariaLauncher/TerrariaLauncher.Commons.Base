using TerrariaLauncher.Commons.Consul.API.CQS.Query;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetLocalServiceHealthResult : ConsulQueryResult
    {
        public ServiceHealthStatus AggregateStatus { get; set; }
        public LocalServiceHealth[] Details { get; set; }
    }
}
