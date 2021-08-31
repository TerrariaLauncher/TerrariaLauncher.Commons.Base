using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Reflection;
using TerrariaLauncher.Commons.Database.CQS.Command;
using TerrariaLauncher.Commons.Database.CQS.Query;

namespace TerrariaLauncher.Commons.Database.CQS.Extensions
{
    internal class DefaultAddDatabaseCQSResult : IAddDatabaseCQSResult
    {
        IServiceCollection services;
        public DefaultAddDatabaseCQSResult(IServiceCollection services)
        {
            this.services = services;
        }

        public IAddDatabaseCQSResult AddHandlers(Assembly assembly)
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
