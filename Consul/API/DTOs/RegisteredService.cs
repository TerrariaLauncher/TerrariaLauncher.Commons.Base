using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public class RegisteredService
    {
        public string ID { get; set; }
        public string Service { get; set; }
        public string[] Tags { get; set; }
        public IDictionary<string, string> Meta { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        public IDictionary<string, TaggedAddress> TaggedAddresses { get; set; }
        public Weights Weights { get; set; }
        public bool EnableTagOverride { get; set; }
        public string Datacenter { get; set; }
    }
}
