namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulCommandResult : ConsulResult, IConsulCommandResult
    {
        protected ConsulCommandResult()
        {
            this.Headers = new ConsulCommandResultHeaders();
        }

        new public ConsulCommandResultHeaders Headers
        {
            get => (this as IConsulResult).Headers as ConsulCommandResultHeaders;
            set => (this as IConsulResult).Headers = value;
        }
    }
}
