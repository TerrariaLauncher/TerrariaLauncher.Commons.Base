using Microsoft.Extensions.DependencyInjection;

namespace TerrariaLauncher.Commons.Consul.API.Extensions
{
    public interface IConsulServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
