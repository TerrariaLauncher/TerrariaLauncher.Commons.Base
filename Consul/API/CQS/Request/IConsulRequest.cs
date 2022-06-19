using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public interface IConsulRequest
    {
        ConsulRequestOptions Options { get; }
    }
}
