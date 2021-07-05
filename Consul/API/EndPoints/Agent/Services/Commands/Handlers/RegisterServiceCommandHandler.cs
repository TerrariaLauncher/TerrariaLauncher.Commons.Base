using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Extensions;

namespace TerrariaLauncher.Commons.Consul.API.Agent.Services.Commands.Handlers
{
    public class RegisterServiceCommandHandler : ConsulCommandHandler<RegisterServiceCommand, RegisterServiceCommandResult>
    {
        protected override Task PrepareRequest(HttpRequestMessage httpRequestMessage, RegisterServiceCommand command, CancellationToken cancellationToken = default)
        {
            var uriBuilder = new UriBuilder(httpRequestMessage.RequestUri);
            if (command.ReplaceExistingChecks)
            {
                uriBuilder.AppendQuery("replace-existing-checks", "true");
            }
            httpRequestMessage.RequestUri = uriBuilder.Uri;
            return Task.CompletedTask;
        }

        protected override Task<RegisterServiceCommandResult> ProcessResponse(HttpResponseMessage httpResponseMessage, RegisterServiceCommand command, CancellationToken cancellationToken = default)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            return Task.FromResult(new RegisterServiceCommandResult());
        }
    }
}
