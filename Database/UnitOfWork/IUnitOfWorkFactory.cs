using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Database
{
    public interface IUnitOfWorkFactory
    {
        string ConnectionString { get; }
        IUnitOfWork Create();
        Task<IUnitOfWork> CreateAsync(CancellationToken cancellationToken = default);
    }
}
