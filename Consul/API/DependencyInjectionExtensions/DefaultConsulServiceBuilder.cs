using Microsoft.Extensions.DependencyInjection;

namespace TerrariaLauncher.Commons.Consul.API.DependencyInjectionExtensions
{
    public class DefaultConsulServiceBuilder : IConsulServiceBuilder
    {
        public DefaultConsulServiceBuilder(IServiceCollection serviceCollection)
        {
            Services = serviceCollection;
        }

        public IServiceCollection Services { get; }
    }
}
