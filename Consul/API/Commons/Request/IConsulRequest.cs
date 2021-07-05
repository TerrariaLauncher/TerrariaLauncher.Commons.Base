using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulRequest
    {
        ConsulRequestOptions Options { get; set; }
    }
}
