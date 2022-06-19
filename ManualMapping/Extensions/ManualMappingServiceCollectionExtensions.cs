using Microsoft.Extensions.DependencyInjection;

namespace TerrariaLauncher.Commons.ManualMapping.Extensions
{
    public static class ManualMappingServiceCollectionExtensions
    {
        public static IManualMappingServiceBuilder AddManualMappingService(this IServiceCollection services)
        {
            services.AddSingleton<IManualMappingDispatcher, ManualMappingDispatcher>();
            return new DefaultManualMappingServiceBuilder(services);
        }
    }
}
