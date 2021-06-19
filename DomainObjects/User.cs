using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UUID { get; set; }
        public string Group { get; set; }
    }
}
