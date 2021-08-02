using System;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public class ConsulConsistencyResponseHeaders
    {
        public TimeSpan? LastContact { get; set; }
        public bool KnownLeader { get; set; }
    }
}
