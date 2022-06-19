using System;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;
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
        public override BlockingOptions Blocking => new BlockingOptions(false);
        public override ConsistencyOptions Consistency => new ConsistencyOptions(false);
        public override AgentCachingOptions AgentCaching => new AgentCachingOptions(AgentCachingForm.None);
        public override HttpOptions Http => new HttpOptions("agent/services", HttpMethod.Get);
    }
}
