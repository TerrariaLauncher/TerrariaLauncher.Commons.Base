using System;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public abstract class ConsulQueryOptions : ConsulRequestOptions
    {
        public class BlockingOptions
        {
            public BlockingOptions(bool supported)
            {
                this.Supported = supported;
            }

            public bool Supported { get; }
            public int? Index { get; set; } = null;
            public string Hash { get; set; } = null;
        }

        public class ConsistencyOptions
        {
            public ConsistencyOptions(bool supported)
            {
                this.Supported = supported;
            }

            public bool Supported { get; }

            public ConsistencyMode Mode { get; set; } = ConsistencyMode.Default;
        }

        public class AgentCachingOptions
        {
            public AgentCachingOptions(AgentCachingForm form)
            {
                this.Form = form;
            }

            public AgentCachingForm Form { get; }

            private bool _enabled = false;
            public bool Enabled
            {
                get => this._enabled;
                set
                {
                    if (this.Form == AgentCachingForm.None)
                    {
                        throw new InvalidOperationException("Can not enable caching if agent caching mode is 'none'.");
                    }
                }
            }

            private CacheControl _cacheControl;
            public CacheControl CacheControl
            {
                get
                {
                    if (this.Form != AgentCachingForm.None)
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
                    if (this.Form == AgentCachingForm.None)
                    {
                        throw new InvalidOperationException("Can not set Cache Control if Agent Caching Mode is 'None'.");
                    }

                    this._cacheControl = value;
                }
            }
        }

        public abstract BlockingOptions Blocking { get; }
        public abstract ConsistencyOptions Consistency { get; }
        public abstract AgentCachingOptions AgentCaching { get; }
    }
}
