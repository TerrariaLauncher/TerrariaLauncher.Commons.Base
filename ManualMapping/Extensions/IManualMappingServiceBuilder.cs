using System.Reflection;

namespace TerrariaLauncher.Commons.ManualMapping.Extensions
{
    public interface IManualMappingServiceBuilder
    {
        IManualMappingServiceBuilder AddHandlers(Assembly assembly);
    }
}
