﻿using TerrariaLauncher.Commons.Consul.API.Commons;
using TerrariaLauncher.Commons.Consul.API.DTOs;

namespace TerrariaLauncher.Commons.Consul.API.EndPoints.KeyValue.Queries
{
    public class ReadKeyQueryResult : ConsulQueryResult
    {
        public KeyValueMetadata[] Metadata { get; set; }
    }
}
