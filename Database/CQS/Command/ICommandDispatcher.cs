using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Command
{
    public interface ICommandDispatcher
    {
        TResult Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand
            where TResult : IResult;

        Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
            where TResult : IResult;
    }
}
