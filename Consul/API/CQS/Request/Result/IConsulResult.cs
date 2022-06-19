using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.CQS.Request
{
    public interface IConsulResult
    {
        ConsulResultMeta Meta { get; set; }
    }
}
