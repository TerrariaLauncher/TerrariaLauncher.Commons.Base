using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public class RequestDispatcher : IRequestDispatcher
    {
        IServiceProvider serviceProvider;
        public RequestDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>
        {
            var handler = this.serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
            return handler.Handle(request, cancellationToken);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
        {
            var handler = this.serviceProvider.GetRequiredService<IRequestHandler<TRequest>>();
            return handler.Handle(request, cancellationToken);
        }
    }
}
