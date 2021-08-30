using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public class MediatorService : IMediatorService
    {
        IRequestDispatcher requestDispatcher;
        INotificationDispatcher notificationDispatcher;
        public MediatorService(
            IRequestDispatcher requestDispatcher,
            INotificationDispatcher notificationDispatcher)
        {
            this.requestDispatcher = requestDispatcher;
            this.notificationDispatcher = notificationDispatcher;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken)
            where TNotification : INotification
        {
            return this.notificationDispatcher.Publish<TNotification>(notification, cancellationToken);
        }

        public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest<TResponse>
        {
            return this.requestDispatcher.Send<TRequest, TResponse>(request, cancellationToken);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest
        {
            return this.requestDispatcher.Send<TRequest>(request, cancellationToken);
        }
    }
}
