using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Query
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        protected readonly ILogger<QueryHandler<TQuery, TResult>> logger;
        protected QueryHandler(ILogger<QueryHandler<TQuery, TResult>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            TResult result = default;

            try
            {
                result = await this.ImplementationAsync(query, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                throw;
            }

            return result;
        }

        protected abstract Task<TResult> ImplementationAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}
