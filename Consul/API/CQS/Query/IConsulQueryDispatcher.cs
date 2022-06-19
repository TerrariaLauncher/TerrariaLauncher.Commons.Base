using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public interface IConsulQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IConsulQuery
            where TResult : IConsulQueryResult;
    }
}
