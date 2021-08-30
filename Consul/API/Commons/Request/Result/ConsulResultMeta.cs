using System.Net;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulResultMeta
    {
        public HttpStatusCode StatusCode { get; set; }
    }
}
