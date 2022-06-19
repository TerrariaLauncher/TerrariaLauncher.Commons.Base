using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Command
{
    public interface IConsulCommand: IConsulRequest
    {
        new ConsulCommandOptions Options { get; }
    }
}
