using System.Net.Http;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulRequestOptions
    {
        public abstract string Path { get; }
        public abstract HttpMethod HttpMethod { get; }
        public string Token { get; set; }
    }
}
