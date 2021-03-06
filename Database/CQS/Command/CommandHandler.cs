using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Database.CQS.Request;

namespace TerrariaLauncher.Commons.Database.CQS.Command
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
        where TResult : IResult
    {
        protected readonly ILogger<CommandHandler<TCommand, TResult>> logger;
        protected CommandHandler(ILogger<CommandHandler<TCommand, TResult>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            TResult result = default;
            try
            {
                result = await this.ImplementationAsync(command, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                throw;
            }

            return result;
        }

        protected abstract Task<TResult> ImplementationAsync(TCommand command, CancellationToken cancellationToken = default);
    }
}
