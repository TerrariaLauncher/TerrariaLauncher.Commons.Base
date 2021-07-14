using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Instance
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
        public bool Enabled { get; set; }
        public string Platform { get; set; }
        public string Version { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public int MaxSlots { get; set; }
    }
}
