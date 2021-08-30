using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public interface INotificationDispatcher
    {
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken)
            where TNotification : INotification;
    }
}
