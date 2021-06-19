using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Group
    {
        public string Name { get; set; }
        public string Base { get; set; }
        public HashSet<string> Commands { get; set; }
        public (byte Red, byte Green, byte Blue) ChatColor { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }
}
