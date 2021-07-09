using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.ConfigurationProvider
{
    public static class ConsulConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder UseConsulConfiguration(
            this IConfigurationBuilder configurationBuilder,
            ConsulHostConfiguration configs, string key)
        {
            return configurationBuilder.Add(new ConsulConfigurationSource(configs, key));
        }
    }
}
