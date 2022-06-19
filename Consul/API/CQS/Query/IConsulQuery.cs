using System;
using System.Net.Http;
using TerrariaLauncher.Commons.Consul.API.CQS.Request;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Query
{
    public interface IConsulQuery : IConsulRequest
    {
        new ConsulQueryOptions Options { get; }
    }
}
