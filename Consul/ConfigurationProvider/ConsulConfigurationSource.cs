using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.ConfigurationProvider
{
    public class ConsulConfigurationSource : IConfigurationSource
    {
        ConsulHostConfiguration configs;
        string key;
        public ConsulConfigurationSource(ConsulHostConfiguration configs, string key)
        {
            this.configs = configs;
            this.key = key;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConsulConfigurationProvider(this.configs, this.key);
        }
    }
}
