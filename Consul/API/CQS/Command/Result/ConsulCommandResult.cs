using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Command
{
    public abstract class ConsulCommandResult : ConsulResult, IConsulCommandResult
    {
        protected ConsulCommandResult()
        {
            this.Meta = new ConsulCommandResultMeta();
        }

        new public ConsulCommandResultMeta Meta
        {
            get => (this as IConsulResult).Meta as ConsulCommandResultMeta;
            set => (this as IConsulResult).Meta = value;
        }
    }
}
