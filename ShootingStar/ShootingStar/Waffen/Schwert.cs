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
        private static int Präfix = 1;
        public string Class = "Schwert";


        public Schwert() 
        {
            
            id = random.Next(1, 10000);
            damage = 10;
            length = 10;
            name = "Schwert_" + Präfix++;
        }    


        public Schwert(bool Special,ConsoleColor Color,string Name , int Damage , int Length)
        {
           
            id = random.Next(1, 10000);
            damage = Damage;
            length = Length;
            color = Color;
            name = name == "" ? Console.ReadLine() : Name;
        }

       
     
    }
}
