using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Reflection;
using TerrariaLauncher.Commons.Database.CQS.Command;
using TerrariaLauncher.Commons.Database.CQS.Query;

namespace TerrariaLauncher.Commons.Database.CQS.Extensions
{
    internal class DefaultDatabaseCQSServiceBuilder : IDatabaseCQSServiceBuilder
    {
        IServiceCollection services;
        public DefaultDatabaseCQSServiceBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        /// <summary>
        /// Command/Query handlers will be stored on other assemblies, not on this library.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public IDatabaseCQSServiceBuilder AddHandlers(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass) continue;
                if (type.IsAbstract) continue;

                Type typeInterface;
                if ((typeInterface = type.GetInterface(typeof(IQueryHandler<,>).Name)) != null ||
                    (typeInterface = type.GetInterface(typeof(ICommandHandler<,>).Name)) != null)
                {
                    services.TryAddSingleton(typeInterface, type);
                }
            }

            return this;
        }
    }
}
