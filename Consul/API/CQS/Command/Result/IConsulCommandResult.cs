using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Command
{
    public interface IConsulCommandResult: IConsulResult
    {
        new ConsulCommandResultMeta Meta { get; set; }
    }
}
