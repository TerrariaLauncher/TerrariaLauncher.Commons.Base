namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public class ConsulQueryResultMeta : ConsulResultMeta
    {
        public ConsulBlockingQueryResponseHeaders BlockingQueryHeaders { get; set; }
        public ConsulConsistencyResponseHeaders ConsistencyHeaders { get; set; }
        public ConsulAgentCachingResponseHeaders AgentCachingHeaders { get; set; }
    }
}
