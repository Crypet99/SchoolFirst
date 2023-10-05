using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Blöcke : Interface 
    {
        public Blöcke() { }

        public int id { get; set; }
        public string name { get; set; }
        public int health { get; set; }

        public string getStats() { return "Stats Blöcke"; }
        public void Save(bool finished) { }
    }
}
