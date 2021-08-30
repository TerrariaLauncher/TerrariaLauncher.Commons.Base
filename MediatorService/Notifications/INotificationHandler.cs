﻿using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.MediatorService
{
    public interface INotificationHandler<TNotification> where TNotification : INotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
