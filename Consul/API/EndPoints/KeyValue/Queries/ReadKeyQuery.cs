using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TerrariaLauncher.Commons.Consul.API.Commons;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.KeyValue.Queries
{
    public class ReadKeyQuery : ConsulQuery
    {
        public ReadKeyQuery() : base(new ReadKeyQueryOptions())
        {

        }

        public ReadKeyQuery(ReadKeyQueryOptions options) : base(options) { }

        public string DataCenter { get; set; }
        public string Key { get; set; }
        public bool Recurse { get; set; }
    }

    public class ReadKeyQueryOptions : ConsulQueryOptions
    {
        public override BlockingOptions Blocking => new BlockingOptions(true);
        public override ConsistencyOptions Consistency => new ConsistencyOptions(true);
        public override AgentCachingOptions AgentCaching => new AgentCachingOptions(AgentCachingForm.None);
        public override HttpOptions Http => new HttpOptions("kv/", HttpMethod.Get);
    }
}
