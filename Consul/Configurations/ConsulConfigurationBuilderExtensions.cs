using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.Configurations
{
    public static class ConsulConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder UseConsulConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            return configurationBuilder.Add(new ConsulConfigurationSource());
        }
    }
}
