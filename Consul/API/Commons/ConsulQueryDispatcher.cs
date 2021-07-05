using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public class ConsulQueryDispatcher : IConsulQueryDispatcher
    {
        IServiceProvider serviceProvider;
        IHttpClientFactory httpClientFactory;
        public ConsulQueryDispatcher(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
        {
            this.serviceProvider = serviceProvider;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IConsulQuery
            where TResult : IConsulQueryResult
        {
            using (var httpClient = this.httpClientFactory.CreateClient("Consul"))
            {
                var handler = this.serviceProvider.GetRequiredService<IConsulQueryHandler<TQuery, TResult>>();
                return await handler.Handle(httpClient, query, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
