using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using System.Text;
using TerrariaLauncher.Commons.Database.CQS.Command;
using TerrariaLauncher.Commons.Database.CQS.Query;

namespace TerrariaLauncher.Commons.Database.CQS.Extensions
{
    public static class DatabaseCQSServiceCollectionExtensions
    {
        public static IDatabaseCQSServiceBuilder AddDatabaseCQS(this IServiceCollection services)
        {
            services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
            return new DefaultDatabaseCQSServiceBuilder(services);
        }
    }
}
