﻿using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulCommandDispatcher
    {
        Task<TConsulCommandResult> Dispatch<TConsulCommand, TConsulCommandResult>(TConsulCommand command, CancellationToken cancellationToken = default)
            where TConsulCommand : IConsulCommand
            where TConsulCommandResult : IConsulCommandResult;
    }
}
