namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulQueryResult: IConsulResult
    {
        new ConsulQueryResultHeaders Headers { get; set; }
    }
}
