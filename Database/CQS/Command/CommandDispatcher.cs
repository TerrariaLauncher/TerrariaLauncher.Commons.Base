using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IServiceProvider serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
            where TResult : IResult
        {
            var handler = this.serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return handler.HandleAsync(command, cancellationToken);
        }
    }
}
