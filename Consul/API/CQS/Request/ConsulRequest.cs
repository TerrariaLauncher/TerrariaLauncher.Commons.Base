using System;
using System.Net.Http;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public abstract class ConsulRequest : IConsulRequest
    {
        protected ConsulRequest(ConsulRequestOptions options)
        {
            this.Options = options;
        }

        public ConsulRequestOptions Options { get; }
    }
}
