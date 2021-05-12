using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Database
{
    public interface IUnitOfWork: IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }
        DbTransaction Transaction { get; }
        DbCommand CreateDbCommand(string commandText = "");

        void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        Task BeginAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken = default);

        T RunQueryHandler<T>(IQuerySingleHandler<T> queryHandler);
        Task<T> RunQueryHandler<T>(IQuerySingleHandlerAsync<T> queryHandler, CancellationToken cancellationToken = default);
        IEnumerable<T> RunQueryHandler<T>(IQueryHandler<T> queryHandler);
        Task<IEnumerable<T>> RunQueryHandler<T>(IQueryHandlerAsync<T> queryHandler, CancellationToken cancellationToken = default);
        IAsyncEnumerable<T> RunQueryHandler<T>(IQueryHandlerAsyncEnumerable<T> queryHandler, CancellationToken cancellationToken = default);

        void RunCommandHandler(ICommandHandler commandHandler);
        T RunCommandHandler<T>(ICommandHandler<T> commandHandler);
        Task RunCommandHandler(ICommandHandlerAsync commandHandler, CancellationToken cancellationToken = default);
        Task<T> RunCommandHandler<T>(ICommandHandlerAsync<T> commandHandler, CancellationToken cancellationToken = default);
    }
}
