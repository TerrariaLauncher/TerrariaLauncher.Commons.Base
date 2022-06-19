using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public interface IConsulQueryResult: IConsulResult
    {
        new ConsulQueryResultMeta Meta { get; set; }
    }
}
