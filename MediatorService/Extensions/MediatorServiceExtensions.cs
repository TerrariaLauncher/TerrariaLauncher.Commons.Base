using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TerrariaLauncher.Commons.MediatorService
{
    public static class MediatorServiceExtensions
    {
        public static IAddMediatorServiceResult AddMediatorService(this IServiceCollection services)
        {
            services.TryAddSingleton<IRequestDispatcher, RequestDispatcher>();
            services.TryAddSingleton<INotificationDispatcher, NotificationDispatcher>();
            services.TryAddSingleton<IMediatorService, MediatorService>();
            
            return new DefaultAddMediatorServiceResult(services);
        }
    }
}
