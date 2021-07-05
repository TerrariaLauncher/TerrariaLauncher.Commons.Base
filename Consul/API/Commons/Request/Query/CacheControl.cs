using System;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public class CacheControl
    {
        public TimeSpan? MaxAge { get; set; }
        public bool MustRevalidate { get; set; }
        public TimeSpan? StaleIfError { get; set; }
    }
}
