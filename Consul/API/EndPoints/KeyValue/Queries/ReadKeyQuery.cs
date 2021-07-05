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
        public override string Path => "kv/";
        public override HttpMethod HttpMethod => HttpMethod.Get;
        public override bool SupportBlocking => true;
        public override bool SupportConsistency => true;
        public override AgentCachingMode SupportAgentCachingMode => AgentCachingMode.None;
    }
}
