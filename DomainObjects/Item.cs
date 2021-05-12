using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Item
    {
        public int Id { get; set; }
        public int Prefix { get; set; }
        public int Stack { get; set; }
    }

    public enum ItemPrefix
    {

    }
}
