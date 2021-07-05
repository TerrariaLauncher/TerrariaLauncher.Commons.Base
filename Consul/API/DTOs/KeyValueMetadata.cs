using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.Consul.API.DTOs
{
    public class KeyValueMetadata
    {
        public int CreateIndex { get; set; }
        public int ModifyIndex { get; set; }
        public string Key { get; set; }
        public uint Flags { get; set; }
        public string Value { get; set; }
        public string Session { get; set; }
    }
}
