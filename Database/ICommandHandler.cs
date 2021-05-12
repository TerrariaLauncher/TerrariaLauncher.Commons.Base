using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Database
{
    public interface ICommandHandler
    {
        bool RequiredTransaction { get; }
        void Handle(DbConnection connection, DbTransaction transaction);
    }

    public interface ICommandHandler<T>
    {
        bool RequiredTransaction { get; }
        T Handle(DbConnection connection, DbTransaction transaction);
    }

    public interface ICommandHandlerAsync
    {
        bool RequiredTransaction { get; }
        Task Handle(DbConnection connection, DbTransaction transaction, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandlerAsync<T>
    {
        bool RequiredTransaction { get; }
        Task<T> Handle(DbConnection connection, DbTransaction transaction, CancellationToken cancellationToken = default);
    }
}
