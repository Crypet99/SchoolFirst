
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Game
    {

        public Game() { }


        #region PlayerInformations

        private Spieler spieler = PlayerSingleton.getInstance();
        string pathChaperOne = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\RPG_ChapterOne.txt";
        string pathChaperTwo = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\RPG_ChapterTwo.txt";
        private Waffen mainWeapon = null;
        private int ReadingTime = 1;
        private string lastText = "";
        private int lastChoice = 0;
        private bool ChapterOneFinished = false;
        private bool ChapterTwoFinished = false;

        #endregion

        #region GameChapters
        public void ChapterOne(int progress)
        {
            string[] tChapterOne = File.ReadAllText(pathChaperOne).Split(';');
            Console.Clear();

            //Anfang der Geschichte
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\tDer Verzauberte Wald\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tChapterOne[progress++]);
            Functions.Sleep(ReadingTime);
            Console.WriteLine(tChapterOne[progress++]);

            //Inventar Auswählen ? Waffe Auswählen ? Intro 

            if (Functions.SelectYesNo("\nMöchtest du dein Inventar Ansehen ?"))
                spieler.OpenInventory();

            if (Functions.SelectYesNo("Möchtest du eine Waffe ausrüsten?"))
            {
                object weapon = spieler.getItem();
                if (weapon is Waffen)
                {
                    mainWeapon = (Waffen)weapon;
                    Console.WriteLine("\nDu hast deine Erste Waffe ausgerüstet\n---------------------\n");
                    ShowStats(mainWeapon);


                }

                else
                {
                    Console.WriteLine("Es wurde keine Waffe ausgewählt");
                    if (mainWeapon == null)
                        mainWeapon = new Fäuste();
                }

            }
            else
                Console.WriteLine("Ein Wahrer Krieger beginnt seine Abenteuer mit seinen Fäusten");
            Functions.Sleep(ReadingTime);
            Console.Clear();

            //-------------------------------------------------------------------------------------------------
            // Weiter im Text
            for (int i = 1; i <= 4; i++)
            {
                lastText = tChapterOne[progress++];
                Console.WriteLine(lastText);
                Functions.Sleep(ReadingTime);
            }
            //Erstes Mal Menue Aufruf
            lastChoice = ShowMenue("1.Der Ausgetretene weg. 2.Der Weniger begangene weg.");

            if (lastChoice == 1)
            {
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine(tChapterOne[progress++]);
                    Functions.Sleep(ReadingTime);
                }
                lastText = tChapterOne[progress];
                Console.WriteLine(lastText);
                int Item_ID = spieler.TakeItem(Inventory.Items.Schwert, true, ConsoleColor.Blue, "The Sword of Ducks", 25, 20);
                Console.WriteLine("Beliebige taste zum Inspizieren drücken...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(lastText);
                Waffen SwordOfDucks = (Waffen)spieler.getItem(Item_ID);
                mainWeapon = SwordOfDucks;
                ShowStats(SwordOfDucks);
                Functions.Sleep(ReadingTime);



                progress += 2; // schlechter pfad überspringen
            }
            else if (lastChoice == 2)
            {
                Console.WriteLine(tChapterOne[progress += 4]); // Guter Pfad überspringen
                progress++;
            }
            Console.WriteLine(tChapterOne[progress]);
            Console.WriteLine("Beliebige Taste Zum Fortführen drücken");
            Console.ReadKey();
            Console.Clear();
            foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.Clear();
                Console.ForegroundColor = c;
                Console.WriteLine("\r\n\r\n\n\n\n\n\n\n\n████████╗██╗   ██╗████████╗ ██████╗ ██████╗ ██╗ █████╗ ██╗     \r\n╚══██╔══╝██║   ██║╚══██╔══╝██╔═══██╗██╔══██╗██║██╔══██╗██║     \r\n   ██║   ██║   ██║   ██║   ██║   ██║██████╔╝██║███████║██║     \r\n   ██║   ██║   ██║   ██║   ██║   ██║██╔══██╗██║██╔══██║██║     \r\n   ██║   ╚██████╔╝   ██║   ╚██████╔╝██║  ██║██║██║  ██║███████╗\r\n   ╚═╝    ╚═════╝    ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚══════╝\r\n██████╗ ███████╗███████╗███╗   ██╗██████╗ ███████╗████████╗    \r\n██╔══██╗██╔════╝██╔════╝████╗  ██║██╔══██╗██╔════╝╚══██╔══╝    \r\n██████╔╝█████╗  █████╗  ██╔██╗ ██║██║  ██║█████╗     ██║       \r\n██╔══██╗██╔══╝  ██╔══╝  ██║╚██╗██║██║  ██║██╔══╝     ██║       \r\n██████╔╝███████╗███████╗██║ ╚████║██████╔╝███████╗   ██║       \r\n╚═════╝ ╚══════╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝   ╚═╝       \r\n\r\n");
                Functions.Sleep(400);

            }
            ChapterOneFinished = true;
            Save(spieler);


        }

        
        public void ChapterTwo(int progress)
        {
            string[] tChapterTwo = File.ReadAllText(pathChaperTwo).Split(';');
            Waldmeister waldmeister = new Waldmeister();
            Battle.BattleTime(spieler, waldmeister);
            Console.ReadKey();

        }

        #endregion

        #region InterfaceMethods
        private void ShowStats(Interface @interface)
        {
            Console.WriteLine(@interface.getStats());
            Console.WriteLine("Beliebige Taste zum Fortfahren drücken");
            Console.ReadKey();
        }

        private void Save(Interface @interface)
        {
            @interface.Save(ChapterOneFinished);
        }

        #endregion

        #region MainMethods

        private int ShowMenue(string StoryAuswahl)
        {


            while (true)
            {
                bool allowed = false;


                Console.WriteLine("\nMenueAuswahl\n------------------");
                Console.WriteLine("1 -> Zur StoryAuswahl");
                Console.WriteLine("2 -> Inventar Ansicht");
                Console.WriteLine("3 -> Waffenwechsel");
                Console.WriteLine("4 -> Craft");
                Console.WriteLine("5 -> Speichern");
                Console.Write("Eingabe : ");
                string selection = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(lastText + "\n");
                if (Functions.IsNumeric(selection))
                {
                    string allowedPatterns = "1,2,3,4,5";

                    if (allowedPatterns.Contains(selection))
                    {
                        allowed = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe");
                    Functions.Sleep(ReadingTime);
                    continue;
                }

                if (allowed)
                {
                    switch (selection)
                    {

                        case "1":
                            {
                                Console.Clear();

                                if (Functions.StorySelection(lastText, StoryAuswahl))
                                    return 1;
                                else
                                    return 2;
                            } //StoryAuswahl 1 oder 2

                        case "2":
                            {
                                spieler.OpenInventory();

                            }
                            break;// Öffne Inventar

                        case "3":
                            {
                                spieler.OpenInventory();
                                object weapon = spieler.getItem();
                                if (weapon is Waffen)
                                    mainWeapon = (Waffen)weapon;
                                else
                                    Console.WriteLine("Es Wurde keine Waffe ausgewählt");
                            }
                            break; //Waffen Wechsel

                        case "4": // In Work
                            {

                            }
                            break; // In Work

                        case "5": // Save 
                            {
                                Save(spieler);
                                Console.WriteLine("Spielstand gespeichert");

                            }
                            break;





                    }
                }








            }
        }


        #endregion




    }
}
