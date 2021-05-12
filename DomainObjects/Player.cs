using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Player
    {
        public const int MaxPlayers = 255;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Inventory Inventory { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }

        public Types.Health Health { get; set; }
        public Types.Mana Mana { get; set; }

        public static class Types
        {
            public class Health
            {
                /// <summary>
                /// Current health.
                /// </summary>
                public int Current { get; set; }
                /// <summary>
                /// Max bare health.
                /// </summary>
                public int Base { get; set; }
                /// <summary>
                /// Max health with items/buffs.
                /// </summary>
                public int Max { get; set; }
            }

            public class Mana
            {
                public int Current { get; set; }
                public int Base { get; set; }
                public int Max { get; set; }
            }
        }
    }
}
