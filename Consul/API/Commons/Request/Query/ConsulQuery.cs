using System;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQuery : ConsulRequest, IConsulQuery
    {
        protected ConsulQuery(ConsulQueryOptions options) : base(options) { }

        new public ConsulQueryOptions Options
        {
            get => base.Options as ConsulQueryOptions;
            set
            {
                base.Options = value;
            }
        }
    }
}
