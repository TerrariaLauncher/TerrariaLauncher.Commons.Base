using System.Net;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public abstract class ConsulResultMeta
    {
        public HttpStatusCode StatusCode { get; set; }
    }
}
