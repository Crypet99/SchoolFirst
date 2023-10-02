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
        Random random = new Random();
        public static int enumNumber = 10;
        public static int Präfix = 1;

        public Fäuste()
        {
            id = random.Next(1, 1000000000);
            damage = 1;
            length = 3;
            name = "Faust_" + Präfix++;
        }
    }
}
