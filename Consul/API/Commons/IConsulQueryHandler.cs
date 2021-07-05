using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulQueryHandler<TQuery, TResult>
        where TQuery : IConsulQuery
        where TResult : IConsulQueryResult

    {
        Task<TResult> Handle(HttpClient httpClient, TQuery query, CancellationToken cancellationToken = default);
    }
}
