using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulCommandHandler<TCommand, TResult> : IConsulCommandHandler<TCommand, TResult>
        where TCommand : IConsulCommand
        where TResult : IConsulCommandResult
    {
        public async Task<TResult> Handle(HttpClient httpClient, TCommand command, CancellationToken cancellationToken = default)
        {
            using (var httpRequestMessage = new HttpRequestMessage())
            {
                httpRequestMessage.Method = command.Options.Http.Method ?? HttpMethod.Get;

                var uriBuilder = new UriBuilder(httpClient.BaseAddress);
                uriBuilder.Path += command.Options.Http.Path;
                httpRequestMessage.RequestUri = uriBuilder.Uri;

                if (!string.IsNullOrWhiteSpace(command.Options.Http.Token))
                {
                    httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", command.Options.Http.Token);
                }

                await this.PrepareRequest(httpRequestMessage, command, cancellationToken).ConfigureAwait(false);
                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false))
                {
                    var result = await this.ProcessResponse(httpResponseMessage, command, cancellationToken).ConfigureAwait(false);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    return result;
                }
            }
        }

        protected abstract Task PrepareRequest(
            HttpRequestMessage httpRequestMessage,
            TCommand command,
            CancellationToken cancellationToken = default);

        protected abstract Task<TResult> ProcessResponse(
            HttpResponseMessage httpResponseMessage,
            TCommand command,
            CancellationToken cancellationToken = default);
    }
}
