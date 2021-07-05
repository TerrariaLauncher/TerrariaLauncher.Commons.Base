using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public class TaggedAddress
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
