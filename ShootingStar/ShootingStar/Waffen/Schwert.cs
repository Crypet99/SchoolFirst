using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ShootingStar
{
    internal class Schwert : Waffen
    {
        Random random = new Random();
        public static int enumNumber = 11;
        public static int Präfix = 1;
        public Schwert() 
        {
            id = random.Next(1, 1000000000);
            damage = 10;
            length = 10;
            name = "Schwert_" + Präfix++;
        }    


        public Schwert(bool Special)
        {
            id = random.Next(1, 1000000000);
            damage = 10;
            length = 15;
            name = Console.ReadLine();
        }

       
     
    }
}
