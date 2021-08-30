namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulCommandResult: IConsulResult
    {
        new ConsulCommandResultMeta Meta { get; set; }
    }
}
