using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Query
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Handle(TQuery query);
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
