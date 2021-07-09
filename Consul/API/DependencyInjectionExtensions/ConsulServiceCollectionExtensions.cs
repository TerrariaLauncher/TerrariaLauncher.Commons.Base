using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.API.DependencyInjectionExtensions;

namespace TerrariaLauncher.Commons.Consul.Extensions
{
    public static class ConsulServiceCollectionExtensions
    {
        public static IConsulServiceBuilder AddConsulService(this IServiceCollection serviceCollection, Action<ConsulHostConfiguration> configureHost)
        {
            var defaultConfig = new ConsulHostConfiguration()
            {
                UseTls = false,
                Host = "localhost",
                Port = 8500
            };
            configureHost(defaultConfig);

            return AddConsulService(serviceCollection, configureHost);
        }

        public static IConsulServiceBuilder AddConsulService(this IServiceCollection serviceCollection, ConsulHostConfiguration config)
        {           

            serviceCollection.AddHttpClient("Consul", httpClient =>
            {
                var schema = config.UseTls ? "https" : "http";
                httpClient.BaseAddress = new Uri($"{schema}://{config.Host}:{config.Port}/v1/");
            });
            serviceCollection.AddSingleton<IConsulQueryDispatcher, ConsulQueryDispatcher>();
            serviceCollection.AddSingleton<IConsulCommandDispatcher, ConsulCommandDispatcher>();

            var executingAssembly = Assembly.GetExecutingAssembly();

            foreach (var type in executingAssembly.GetExportedTypes())
            {
                if (!type.IsClass) continue;
                if (type.IsAbstract) continue;

                Type typeInterface = null;
                if ((typeInterface = type.GetInterface(typeof(IConsulQueryHandler<,>).Name)) != null)
                {
                    serviceCollection.AddSingleton(typeInterface, type);
                }
                else if ((typeInterface = type.GetInterface(typeof(IConsulCommandHandler<,>).Name)) != null)
                {
                    serviceCollection.AddSingleton(typeInterface, type);
                }
            }

            return new DefaultConsulServiceBuilder(serviceCollection);
        }
    }
}
