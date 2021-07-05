using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulCommandHandler<TCommand, TCommandResult>
        where TCommand : IConsulCommand
        where TCommandResult : IConsulCommandResult
    {
        Task<TCommandResult> Handle(HttpClient httpClient, TCommand command, CancellationToken cancellationToken = default);
    }
}
