using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.Commons
{
    public interface IConsulResult
    {
        ConsulResultMeta Meta { get; set; }
    }
}
