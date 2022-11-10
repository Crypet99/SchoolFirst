using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Türsteher
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Name = "";
            int Alter = 0;

            while (true)
            {

                Console.WriteLine("Bitte gib deinen Namen ein :");
                Name = Console.ReadLine();

                if (Name == "Ende" || Name == "ende")
                {
                    break;
                }

                do
                {
                    try
                    {
                        Console.WriteLine("Bitte gib dein Alter ein");
                        Alter = Convert.ToInt32(Console.ReadLine());
                        break;
                    }

                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);

                    }

                } while (true);

                if (CheckAge(Alter))
                {

                    Console.WriteLine("Hallo {0}, du darfst rein", Name);
                }

                else if (!CheckAge(Alter))
                {
                    Console.WriteLine("Hallo {0}, du darfst nicht rein", Name);
                }

        
            }
            
        }
        

        static bool CheckAge(int Age)
        {
            return Age >= 18;
        }




    }

   
}
