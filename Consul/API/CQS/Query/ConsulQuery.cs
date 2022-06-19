using System;
using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public abstract class ConsulQuery : ConsulRequest, IConsulQuery
    {
        protected ConsulQuery(ConsulQueryOptions options) : base(options) { }

        new public ConsulQueryOptions Options
        {
            get => base.Options as ConsulQueryOptions;
        }
    }
}
