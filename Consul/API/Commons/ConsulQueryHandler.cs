using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TerrariaLauncher.Commons.Extensions;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQueryHandler<TQuery, TResult> : IConsulQueryHandler<TQuery, TResult>
        where TQuery : IConsulQuery
        where TResult : IConsulQueryResult
    {
        public async Task<TResult> Handle(HttpClient httpClient, TQuery query, CancellationToken cancellationToken = default)
        {

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                httpRequestMessage.Method = query.Options.HttpMethod ?? HttpMethod.Get;

                var uriBuilder = new UriBuilder(httpClient.BaseAddress);
                uriBuilder.Path += query.Options.Path;

                if (query.Options.SupportBlocking)
                {
                    if (query.Options.Index.HasValue)
                    {
                        uriBuilder.AppendQuery("index", query.Options.Index.Value.ToString());
                    }
                    else if (string.IsNullOrWhiteSpace(query.Options.Hash))
                    {
                        uriBuilder.AppendQuery("hash", query.Options.Hash);
                    }
                }

                if (query.Options.SupportConsistency)
                {
                    if (query.Options.ConsistencyMode != ConsistencyMode.Default)
                    {
                        uriBuilder.AppendQuery(ConsistencyMode.Consistent.ToString());
                    }
                }

                if (query.Options.SupportAgentCachingMode != AgentCachingMode.None && query.Options.CachingEnabled)
                {
                    uriBuilder.AppendQuery("cached");
                    if (query.Options.SupportAgentCachingMode == AgentCachingMode.Simple)
                    {
                        if (query.Options.CacheControl.MaxAge.HasValue)
                        {
                            httpRequestMessage.Headers.CacheControl.MaxAge = query.Options.CacheControl.MaxAge.Value;
                        }

                        if (query.Options.CacheControl.MustRevalidate)
                        {
                            httpRequestMessage.Headers.CacheControl.MustRevalidate = true;
                        }

                        if (query.Options.CacheControl.StaleIfError.HasValue)
                        {
                            httpRequestMessage.Headers.Add("Cache-Control", $"stale-if-error={Convert.ToInt32(query.Options.CacheControl.StaleIfError.Value.TotalSeconds)}");
                        }
                    }
                }

                httpRequestMessage.RequestUri = uriBuilder.Uri;

                if (!string.IsNullOrWhiteSpace(query.Options.Token))
                {
                    httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", query.Options.Token);
                }

                await this.PrepareRequest(httpRequestMessage, query, cancellationToken).ConfigureAwait(false);

                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false))
                {
                    var result = await this.ProcessResponse(httpResponseMessage, query, cancellationToken).ConfigureAwait(false);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    if (query.Options.SupportBlocking)
                    {
                        result.Headers.BlockingQueryHeaders = new ConsulBlockingQueryResponseHeaders();
                        if (httpResponseMessage.Headers.TryGetValues("X-Consul-Index", out var values))
                        {
                            result.Headers.BlockingQueryHeaders.Index = Convert.ToInt32(values.First());
                        }
                    }

                    if (query.Options.CachingEnabled)
                    {
                        result.Headers.AgentCachingHeaders = new ConsulAgentCachingResponseHeaders();
                        if (httpResponseMessage.Headers.TryGetValues("X-Cache", out var values))
                        {
                            if (values.First().Equals("HIT", StringComparison.OrdinalIgnoreCase))
                            {
                                result.Headers.AgentCachingHeaders.CacheHit = true;

                                if (httpResponseMessage.Headers.Age.HasValue)
                                {
                                    result.Headers.AgentCachingHeaders.Age = httpResponseMessage.Headers.Age.Value;
                                }
                            }
                        }
                    }

                    if (query.Options.SupportConsistency)
                    {
                        result.Headers.ConsistencyHeaders = new ConsulConsistencyResponseHeaders();
                        if (httpResponseMessage.Headers.TryGetValues("X-Consul-LastContact", out var values))
                        {
                            result.Headers.ConsistencyHeaders.LastContact = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(values.First()));
                        }

                        if (httpResponseMessage.Headers.TryGetValues("X-Consul-KnownLeader", out values))
                        {
                            result.Headers.ConsistencyHeaders.KnownLeader = Convert.ToBoolean(values.First());
                        }
                    }

                    return result;
                }
            }
        }

        protected abstract Task PrepareRequest(
            HttpRequestMessage httpRequestMessage,
            TQuery query,
            CancellationToken cancellationToken = default);

        protected abstract Task<TResult> ProcessResponse(
            HttpResponseMessage httpResponseMessage,
            TQuery query,
            CancellationToken cancellationToken = default);
    }
}
