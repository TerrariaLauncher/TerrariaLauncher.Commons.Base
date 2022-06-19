using System.Net.Http;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public abstract class ConsulRequestOptions
    {
        public class HttpOptions
        {
            public HttpOptions(string path, HttpMethod httpMethod)
            {
                this.Path = path;
                this.Method = httpMethod;
            }

            public string Path { get; }
            public HttpMethod Method { get; }
            public bool BypassUnsuccessfulStatusCode { get; set; }
            public string Token { get; set; }
        }

        public abstract HttpOptions Http { get; }
    }
}
