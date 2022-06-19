using System.Net.Http;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries
{
    public class GetLocalServiceHealth : ConsulQuery
    {
        public GetLocalServiceHealth() : this(new GetLocalServiceHealthOptions()) { }
        public GetLocalServiceHealth(GetLocalServiceHealthOptions options) : base(options)
        {
            base.Options.Http.BypassUnsuccessfulStatusCode = true;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class GetLocalServiceHealthOptions : ConsulQueryOptions
    {
        public override BlockingOptions Blocking => new BlockingOptions(false);
        public override ConsistencyOptions Consistency => new ConsistencyOptions(false);
        public override AgentCachingOptions AgentCaching => new AgentCachingOptions(AgentCachingForm.None);
        public override HttpOptions Http => new HttpOptions("agent/health/service", HttpMethod.Get);
    }
}
