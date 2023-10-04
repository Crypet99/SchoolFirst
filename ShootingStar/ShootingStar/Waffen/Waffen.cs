using ShootingStar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Waffen : Interface
    {
        public Waffen() { }

        
        public string name { get; set; }
        public int damage { get; set; }
        public int length { get; set; }
        public int id { get; set; }
        public ConsoleColor color { get; set; }

        public string getStats() 
        {
            StringBuilder sb = new StringBuilder();
        
            sb.AppendLine("Weapon : " + name);
            sb.AppendLine("Damage : " + damage);
            sb.AppendLine("Length : " + length);
            sb.AppendLine("Colors : " + color);

            return sb.ToString(); 
        }

        public void Save() { }
        

        


    }
}
