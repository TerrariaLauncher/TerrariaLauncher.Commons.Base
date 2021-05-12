using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Database
{
    public interface IQuerySingleHandler<T>
    {
        T Handle(DbConnection connection, DbTransaction transaction);
    }

    public interface IQuerySingleHandlerAsync<T>
    {
        Task<T> HandleAsync(DbConnection connection, DbTransaction transaction, CancellationToken cancellationToken = default);
    }

    public interface IQueryHandler<T>
    {
        IEnumerable<T> Handle(DbConnection connection, DbTransaction transaction);
    }

    public interface IQueryHandlerAsync<T>
    {
        Task<IEnumerable<T>> HandleAsync(DbConnection connection, DbTransaction transaction, CancellationToken cancellationToken = default);
    }

    public interface IQueryHandlerAsyncEnumerable<T>
    {
        IAsyncEnumerable<T> HandleAsync(DbConnection connection, DbTransaction transaction, CancellationToken cancellationToken = default);
    }
}
