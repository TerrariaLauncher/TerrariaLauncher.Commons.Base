using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Command
{
    public abstract class ConsulCommand : ConsulRequest, IConsulCommand
    {
        protected ConsulCommand(ConsulCommandOptions options) : base(options) { }

        new public ConsulCommandOptions Options
        {
            get => base.Options as ConsulCommandOptions;
        }
    }
}
