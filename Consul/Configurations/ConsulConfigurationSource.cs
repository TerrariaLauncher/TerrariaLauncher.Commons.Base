using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.Configurations
{
    public class ConsulConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
