using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Consul.API.CQS.Command;
using TerrariaLauncher.Commons.Extensions;

namespace TerrariaLauncher.Commons.Consul.API.Agent.Services.Commands
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

            var json = JsonSerializer.Serialize(command.Registration);
            httpRequestMessage.Content = new StringContent(json, new UTF8Encoding(), "application/json");
            return Task.CompletedTask;
        }

        protected override Task<RegisterServiceCommandResult> ProcessResponse(HttpResponseMessage httpResponseMessage, RegisterServiceCommand command, CancellationToken cancellationToken = default)
        {
            httpResponseMessage.EnsureSuccessStatusCode();
            return Task.FromResult(new RegisterServiceCommandResult());
        }
    }
}
