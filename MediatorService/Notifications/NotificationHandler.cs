using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public abstract class NotificationHandler<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        public Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            return this.Implementation(notification, cancellationToken);
        }

        protected abstract Task Implementation(TNotification notification, CancellationToken cancellationToken);
    }
}
