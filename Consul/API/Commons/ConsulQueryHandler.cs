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
                httpRequestMessage.Method = query.Options.Http.Method ?? HttpMethod.Get;

                var uriBuilder = new UriBuilder(httpClient.BaseAddress);
                uriBuilder.Path += query.Options.Http.Path;

                if (query.Options.Blocking.Supported)
                {
                    if (query.Options.Blocking.Index.HasValue)
                    {
                        uriBuilder.AppendQuery("index", query.Options.Blocking.Index.Value.ToString());
                    }
                    else if (!string.IsNullOrWhiteSpace(query.Options.Blocking.Hash))
                    {
                        uriBuilder.AppendQuery("hash", query.Options.Blocking.Hash);
                    }
                }

                if (query.Options.Consistency.Supported)
                {
                    if (query.Options.Consistency.Mode != ConsistencyMode.Default)
                    {
                        uriBuilder.AppendQuery(ConsistencyMode.Consistent.ToString());
                    }
                }

                if (query.Options.AgentCaching.Form != AgentCachingForm.None && query.Options.AgentCaching.Enabled)
                {
                    uriBuilder.AppendQuery("cached");
                    if (query.Options.AgentCaching.Form == AgentCachingForm.Simple)
                    {
                        if (query.Options.AgentCaching.CacheControl.MaxAge.HasValue)
                        {
                            httpRequestMessage.Headers.CacheControl.MaxAge = query.Options.AgentCaching.CacheControl.MaxAge.Value;
                        }

                        if (query.Options.AgentCaching.CacheControl.MustRevalidate)
                        {
                            httpRequestMessage.Headers.CacheControl.MustRevalidate = true;
                        }

                        if (query.Options.AgentCaching.CacheControl.StaleIfError.HasValue)
                        {
                            httpRequestMessage.Headers.Add("Cache-Control", $"stale-if-error={Convert.ToInt32(query.Options.AgentCaching.CacheControl.StaleIfError.Value.TotalSeconds)}");
                        }
                    }
                }

                httpRequestMessage.RequestUri = uriBuilder.Uri;

                if (!string.IsNullOrWhiteSpace(query.Options.Http.Token))
                {
                    httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", query.Options.Http.Token);
                }

                await this.PrepareRequest(httpRequestMessage, query, cancellationToken).ConfigureAwait(false);

                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false))
                {
                    var result = await this.ProcessResponse(httpResponseMessage, query, cancellationToken).ConfigureAwait(false);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    if (query.Options.Blocking.Supported)
                    {
                        result.Headers.BlockingQueryHeaders = new ConsulBlockingQueryResponseHeaders();
                        if (httpResponseMessage.Headers.TryGetValues("X-Consul-Index", out var values))
                        {
                            result.Headers.BlockingQueryHeaders.Index = Convert.ToInt32(values.First());
                        }
                    }

                    if (query.Options.AgentCaching.Enabled)
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

                    if (query.Options.Consistency.Supported)
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
