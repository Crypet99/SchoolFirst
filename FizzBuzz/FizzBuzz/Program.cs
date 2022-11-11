using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte Zahl1 = 0;

            for (Zahl1 = 0; Zahl1 < 101; Zahl1++)
            {
                if (Zahl1 %3 == 0 && Zahl1 % 5 == 0)
                {
                        Console.WriteLine("Fizzbuzz");
                }
                else if (Zahl1 % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                else if (Zahl1 % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                    Console.WriteLine(Zahl1);


            }
            Console.ReadLine();




        }
    }
}
