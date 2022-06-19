using System;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public class ConsulAgentCachingResponseHeaders
    {
        public bool CacheHit { get; set; }
        public TimeSpan? Age { get; set; }
    }
}
