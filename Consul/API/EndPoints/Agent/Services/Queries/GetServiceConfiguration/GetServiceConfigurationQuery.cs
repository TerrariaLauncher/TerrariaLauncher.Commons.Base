using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.CQS.Query;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.Agent.Services.Queries.GetServiceConfiguration
{
    public class GetServiceConfigurationQuery : ConsulQuery
    {
        public GetServiceConfigurationQuery(GetServiceConfigurationQueryOptions options) : base(options) { }
        public GetServiceConfigurationQuery() : this(new GetServiceConfigurationQueryOptions()) { }

        public string ServiceId { get; set; }
    }

    public class GetServiceConfigurationQueryOptions : ConsulQueryOptions
    {
        public override BlockingOptions Blocking => new BlockingOptions(true);
        public override ConsistencyOptions Consistency => new ConsistencyOptions(false);
        public override AgentCachingOptions AgentCaching => new AgentCachingOptions(AgentCachingForm.None);
        public override HttpOptions Http => new HttpOptions("agent/service/", HttpMethod.Get);
    }

    public class GetServiceConfigurationResult : ConsulQueryResult
    {
        public RegisteredService Service { get; set; }
    }
}
