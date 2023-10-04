using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar.Items
{
    internal class Loot
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Loot(bool special = false ,string Name = "Dreck") { name = Name;  }
    }
}
