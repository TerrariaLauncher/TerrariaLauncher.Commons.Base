using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Immutable;
using System.Reflection;

namespace TerrariaLauncher.Commons.MediatorService
{
    internal class DefaultAddMediatorServiceResult : IAddMediatorServiceResult
    {
        IServiceCollection services;
        public DefaultAddMediatorServiceResult(IServiceCollection services)
        {
            this.services = services;
        }

        public IAddMediatorServiceResult AddMediatorHandlers(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass) continue;
                if (type.IsAbstract) continue;

                Type typeInterface;
                if ((typeInterface = type.GetInterface(typeof(IRequestHandler<>).Name)) != null ||
                    (typeInterface = type.GetInterface(typeof(IRequestHandler<,>).Name)) != null)
                {
                    this.services.TryAddSingleton(typeInterface, type);
                }
                else if ((typeInterface = type.GetInterface(typeof(INotificationHandler<>).Name)) != null)
                {
                    this.services.TryAddEnumerable(new ServiceDescriptor(typeInterface, type, ServiceLifetime.Singleton));
                }
            }

            return this;
        }
    }
}
