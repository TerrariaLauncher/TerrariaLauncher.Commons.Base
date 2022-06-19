using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace TerrariaLauncher.Commons.ManualMapping.Extensions
{
    internal class DefaultManualMappingServiceBuilder : IManualMappingServiceBuilder
    {
        IServiceCollection services;
        public DefaultManualMappingServiceBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IManualMappingServiceBuilder AddHandlers(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass) continue;
                if (type.IsAbstract) continue;

                Type interfaceType;
                interfaceType = type.GetInterface(typeof(IManualMappingHandler<,>).Name);
                if (interfaceType != null)
                {
                    this.services.AddSingleton(interfaceType, type);
                }
            }
            return this;
        }
    }
}