namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulCommand: IConsulRequest
    {
        new ConsulCommandOptions Options { get; set; }
    }
}
