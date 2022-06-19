using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Command
{
    public class ConsulCommandDispatcher : IConsulCommandDispatcher
    {
        IServiceProvider serviceProvider;
        IHttpClientFactory httpClientFactory;
        public ConsulCommandDispatcher(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
        {
            this.serviceProvider = serviceProvider;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<TConsulCommandResult> Dispatch<TConsulCommand, TConsulCommandResult>(TConsulCommand command, CancellationToken cancellationToken = default)
            where TConsulCommand : IConsulCommand
            where TConsulCommandResult : IConsulCommandResult
        {
            var handler = this.serviceProvider.GetRequiredService<IConsulCommandHandler<TConsulCommand, TConsulCommandResult>>();
            using (var httpClient = this.httpClientFactory.CreateClient("Consul"))
            {
                return await handler.Handle(httpClient, command, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
