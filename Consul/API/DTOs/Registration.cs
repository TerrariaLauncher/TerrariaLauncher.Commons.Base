using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public class Registration
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
        public string ID { get; set; }
        public string[] Tags { get; set; }
        public string Address { get; set; }
        public IDictionary<string, string> Meta { get; set; }
        public int Port { get; set; }
        public string Kind { get; set; }

        public Check Check { get; set; }
        public Check[] Checks { get; set; }
        public bool EnableTagOverride { get; set; }
    }
}
