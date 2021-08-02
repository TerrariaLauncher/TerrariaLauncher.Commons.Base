namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public class ConsulQueryResultHeaders : ConsulResultHeaders
    {
        public ConsulBlockingQueryResponseHeaders BlockingQueryHeaders { get; set; }
        public ConsulConsistencyResponseHeaders ConsistencyHeaders { get; set; }
        public ConsulAgentCachingResponseHeaders AgentCachingHeaders { get; set; }
    }
}
