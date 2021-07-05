using System;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQueryOptions : ConsulRequestOptions
    {
        public abstract AgentCachingMode SupportAgentCachingMode { get; }
        public abstract bool SupportConsistency { get; }
        public abstract bool SupportBlocking { get; }

        public ConsistencyMode ConsistencyMode { get; set; } = ConsistencyMode.Default;

        private bool _cachingEnabled = false;
        public bool CachingEnabled
        {
            get => this._cachingEnabled;
            set
            {
                if (this.SupportAgentCachingMode == AgentCachingMode.None)
                {
                    throw new InvalidOperationException("Can not enable caching if agent caching mode is 'none'.");
                }

                this._cachingEnabled = value;
            }
        }

        private CacheControl _cacheControl;
        public CacheControl CacheControl
        {
            get
            {
                if (this.SupportAgentCachingMode != AgentCachingMode.None)
                {
                    if (this._cacheControl is null)
                    {
                        this._cacheControl = new CacheControl();
                    }
                }

                return this._cacheControl;
            }
            set
            {
                if (this.SupportAgentCachingMode == AgentCachingMode.None)
                {
                    throw new InvalidOperationException("Can not set Cache Control if Agent Caching Mode is 'None'.");
                }

                this._cacheControl = value;
            }
        }

        public int? Index { get; set; } = null;
        public string Hash { get; set; } = null;
    }
}
