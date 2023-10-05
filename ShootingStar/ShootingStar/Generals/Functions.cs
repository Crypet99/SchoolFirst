using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    static internal class Functions
    {
        #region Hilfsfunktionen
        public static bool SelectYesNo(string lastText)
        {
            string value = "";
            
            do
            {
                try
                {
                    Console.WriteLine(lastText);
                    Console.Write("Eingabe : ");
                    value = Console.ReadLine();
                    Console.Clear();
                

                    if (!(value.ToLower() == "ja" || value.ToLower() == "nein"))
                    {
                        
                        Console.WriteLine("Bitte Ja oder Nein als Antwort geben\n");
                        Functions.Sleep(2000);
                        Console.Clear();
                    }
                }
               
                catch (Exception ex) { Console.WriteLine(ex.Message); Console.Clear(); ; continue; }
            } while (!(value.ToLower() == "ja" || value.ToLower() == "nein"));

            return value == "Ja" ? true : false;


        }

        public static bool StorySelection(string lastText , string StorySelection)
        {
            byte value = 0;
            bool? yesNo = null;
            
            
            do
            {
                try
                {
                    Console.WriteLine(lastText);
                    Console.WriteLine(StorySelection);
                    Console.Write("Eingabe : ");
                    value = Convert.ToByte(Console.ReadLine());

                    if (value == 1)
                        yesNo = true;
                    else if (value == 2)
                        yesNo = false;
                    else
                        yesNo = null;

                    if (yesNo == null)
                    {
                        Console.WriteLine("Bitte eine gültige Ziffer von 1 oder 2 eingeben");
                        Functions.Sleep(2000);
                        
                    }
                    Console.Clear();
                    
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); Console.Clear();  continue; }
            } while (!(value == 1 || value == 2));

            return value == 1 ? true : false;
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public static void Sleep(int value)
        {
            System.Threading.Thread.Sleep(value);
        }

        #endregion
    }
}
