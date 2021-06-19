using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Commons;

namespace TerrariaLauncher.Commons.Database.CQS.Command
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
        where TResult: IResult
    {
        TResult Handle(TCommand command);
        Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
