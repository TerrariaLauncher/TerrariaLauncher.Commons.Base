using System;
using System.Net.Http;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulQuery : IConsulRequest
    {
        new ConsulQueryOptions Options { get; }
    }
}
