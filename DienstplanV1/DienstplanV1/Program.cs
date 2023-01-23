using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienstplanV1
{
    internal class Program
    {

       
        static void Main(string[] args)
        {

            Menue Programm_Menue = new Menue();
            Console.WriteLine("Willkommen zu Ihrem Dienstplan Programm.");
    
            Programm_Menue.StartMenue();


        }
    }
}
