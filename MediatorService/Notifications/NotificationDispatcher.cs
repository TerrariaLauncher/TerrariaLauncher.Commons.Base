using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public class NotificationDispatcher : INotificationDispatcher
    {
        IServiceProvider serviceProvider;
        public NotificationDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            var handlers = this.serviceProvider.GetServices<INotificationHandler<INotification>>();
            foreach (var handle in handlers)
            {
                await handle.Handle(notification, cancellationToken);
            }
        }
    }
}
