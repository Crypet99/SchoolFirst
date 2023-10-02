using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Game
    {

        public Game() { }
        private Spieler spieler = PlayerSingleton.getInstance();
        string pathChaperOne = @"C:\Users\Student\Desktop\CHSU\RPG_ChapterOne.txt";
        
        public bool? yesNo = false;
        


        public void ChapterOne(int progress)
        {
            string[] tChapterOne = File.ReadAllText(pathChaperOne).Split(';');
            Console.Clear();

            //Anfang Stats Initialisieren
            {
                spieler.TakeItem(Inventory.Items.Faust);
                spieler.TakeItem(Inventory.Items.Faust);
                spieler.TakeItem(Inventory.Items.Schwert);

                spieler.TakeItem(Inventory.Items.Erdblock);
                spieler.TakeItem(Inventory.Items.Erdblock);
                spieler.TakeItem(Inventory.Items.Erdblock);
                
            }


            //Anfang der Geschichte
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\tDer Verzauberte Wald");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tChapterOne[progress++]);
            System.Threading.Thread.Sleep(2500);
            Console.WriteLine(tChapterOne[progress++]);

            //Inventar Auswählen ? 
            Console.WriteLine("\nMöchtest du dein Inventar Ansehen ?\n 1.Ja\n2.Nein");
            if(SelectYesNo());
            spieler.OpenInventory();

            while(true)
            {
                spieler.getItem();
            }
       
           






            Console.ReadKey();


        }

        private static bool SelectYesNo()
        {
            byte value = 0;
            bool? yesNo = null;
            do
            {
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
                    System.Threading.Thread.Sleep(1000);
                 
                
                }
                Console.Clear();
            } while (!(value == 1 || value == 2));

            return value == 1 ? true : false;

        
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }




    }
}
