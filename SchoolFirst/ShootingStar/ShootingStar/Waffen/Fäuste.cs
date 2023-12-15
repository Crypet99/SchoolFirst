using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ShootingStar
{
    internal class Fäuste:Waffen
    {
        public string Class = "Fäuste";
        public static int enumNumber = 10;
        public static int Präfix = 1;

        public Fäuste()
        {
            Random random = new Random();
            id = random.Next(1, 10000);
            damage = 1;
            length = 3;
            name = "Faust_" + Präfix++;
        }
    }
}
