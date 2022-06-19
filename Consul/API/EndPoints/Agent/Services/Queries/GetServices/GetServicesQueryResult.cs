using System.Collections.Generic;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetServicesQueryResult: ConsulQueryResult
    {
        public IDictionary<string, RegisteredService> Services { get; set; }
    }
}
