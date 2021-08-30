using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return this.Implementation(request, cancellationToken);
        }

        protected abstract Task<TResponse> Implementation(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class RequestHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        public Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            return this.Implementation(request, cancellationToken);
        }

        protected abstract Task Implementation(TRequest request, CancellationToken cancellationToken);
    }
}
