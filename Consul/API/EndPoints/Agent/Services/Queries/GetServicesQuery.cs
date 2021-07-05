using System;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.Filter;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetServicesQuery : ConsulQuery
    {
        public GetServicesQuery() : base(new GetServicesQueryOptions()) { }
        public GetServicesQuery(GetServicesQueryOptions options) : base(options) { }

        public ConsulFilter Query { get; set; }
    }

    public class GetServicesQueryOptions : ConsulQueryOptions
    {
        public override string Path => "agent/services";
        public override HttpMethod HttpMethod => HttpMethod.Get;

        public override AgentCachingMode SupportAgentCachingMode => AgentCachingMode.None;
        public override bool SupportConsistency => false;
        public override bool SupportBlocking => false;
    }
}
