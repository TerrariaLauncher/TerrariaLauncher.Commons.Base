namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulQueryResult: IConsulResult
    {
        new ConsulQueryResultMeta Meta { get; set; }
    }
}
