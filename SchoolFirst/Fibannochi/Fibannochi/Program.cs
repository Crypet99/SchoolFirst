using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibannochi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exit = 1;
            int a = 0;
            int b = 1;
            int c = 1;
            int number = 0;


            Console.WriteLine("Wie weit möchten sie die Reihe anzeigen lassen ?");
            exit = Convert.ToInt32(Console.ReadLine());

            Addiere(a, b, c, exit, number);
            Console.ReadLine();

        }

        static void Addiere(int a, int b, int c, int exit, int number)
        {

            Console.WriteLine(a);

            c = a + b;
            a = b;
            b = c;


            number++;

            if (number < exit)
            {
                Addiere(a, b, c, exit, number);
            }

            



        }
    }


}
