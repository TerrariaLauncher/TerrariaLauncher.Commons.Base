using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public class ConsulQueryResultMeta : ConsulResultMeta
    {
        public ConsulBlockingQueryResponseHeaders BlockingQueryHeaders { get; set; }
        public ConsulConsistencyResponseHeaders ConsistencyHeaders { get; set; }
        public ConsulAgentCachingResponseHeaders AgentCachingHeaders { get; set; }
    }
}
