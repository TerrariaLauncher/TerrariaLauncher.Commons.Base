using System;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public class ConsulConsistencyResponseHeaders
    {
        public TimeSpan? LastContact { get; set; }
        public bool KnownLeader { get; set; }
    }
}
