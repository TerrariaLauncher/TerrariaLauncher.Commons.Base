namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulCommandResult: IConsulResult
    {
        new ConsulCommandResultHeaders Headers { get; set; }
    }
}
