using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar.Items
{
    internal class Loot
    {
        public string Class = "Loot";
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int healthpoints { get; set; }
        public Loot(bool special = false ,string Name = "Dreck" ,string description = "" , int healthpoints = 10) { name = Name;  }
    }
}
