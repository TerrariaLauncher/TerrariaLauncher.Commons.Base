using System.Net.Http;

namespace TerrariaLauncher.Commons.Consul.API.Commons
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
            public string Token { get; set; }
        }

        public abstract HttpOptions Http { get; }
    }
}
