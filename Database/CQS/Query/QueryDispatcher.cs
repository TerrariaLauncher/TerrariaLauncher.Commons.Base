using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        IServiceProvider serviceProvider;
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery
            where TResult : IResult
        {
            var handler = this.serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.HandleAsync(query, cancellationToken);
        }
    }
}
