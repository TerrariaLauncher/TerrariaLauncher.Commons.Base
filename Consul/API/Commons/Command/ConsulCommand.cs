namespace TerrariaLauncher.Commons.Consul.API.Commons
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
