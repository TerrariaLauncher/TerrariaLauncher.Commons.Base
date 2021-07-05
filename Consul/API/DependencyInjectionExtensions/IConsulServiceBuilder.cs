using Microsoft.Extensions.DependencyInjection;

namespace TerrariaLauncher.Commons.Consul.API.DependencyInjectionExtensions
{
    public interface IConsulServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
