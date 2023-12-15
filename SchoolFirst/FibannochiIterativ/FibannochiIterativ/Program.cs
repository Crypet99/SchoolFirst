using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibannochiIterativ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            Console.WriteLine("Wie viele Zahlen sollen angegeben werden");
            exit = Convert.ToInt32(Console.ReadLine());
            int a = 0;
            int b = 1;
            int c = 1;

            for (int i = 0; i < exit; i++)
            {
                Console.WriteLine(c);

                a = b;
                b = c;
                c = a+b;

                

            }

            Console.ReadLine();



        }
    }
}
