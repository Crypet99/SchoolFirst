using System;
using System.Collections.Generic;

namespace Enum_s
{
    internal class Program
    {

       enum Tools
        {
            Scissor = 1,
            Rock,
            Paper,
            Lizard,
            Spock,
            Count
        }

        static void Main(string[] args)
        {

            
            
            //Variablen
            int wins = 0;
            int looses = 0;
            int Games = 0;
            int userScissor = 0;
            int userRock = 0;
            int userPaper = 0;
            int userLizard = 0;
            int userSpock = 0;
            int Mode = 0;
            int Probability = 0;
            Tools playerTool = Tools.Count;
            Tools EnemyTool;



            while (true)
            {


                Random random = new Random();
                int rnd = random.Next(Tools.Scissor.GetHashCode(), Tools.Count.GetHashCode());

                Console.WriteLine("Please Choose a Tool for The Game");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("-S-{0}\n-R-{1}\n-P-{2}\n-L-{3}\n-Z-{4}\n-Q-Quit\n", Tools.Scissor , Tools.Rock,Tools.Paper,Tools.Lizard, Tools.Spock);
                

                // Show Games
                if (Games > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Games Won {0}  || Games Played {1}", wins, Games);
                    Console.WriteLine("Probability{0}  || Mode {1}", Probability, Mode);
                }

                // Logic
                if (Games >= 10)
                {
                    Mode = CheckMode(wins, looses);

                    Random Wsl = new Random();
                    Probability = Wsl.Next(0, 101);

                    if (Probability < Mode)
                    {
                        EnemyTool = GetEasyTool(playerTool, userScissor, userRock, userPaper, userLizard, userSpock);
                        rnd = EnemyTool.GetHashCode();
                        
                    }
                }


                // Input Character
                char userInput = Console.ReadKey().KeyChar;

                //Quit Game
                if (userInput == 'Q' || userInput == 'q')
                {
                    break;
                }

                // Choose Tool
                playerTool =  ChooseTool(playerTool, userInput);
                Console.Clear();

                // Count Typed Tools
                if(playerTool.GetHashCode() == 1)
                {
                    userScissor += 1;
                }
                else if(playerTool.GetHashCode() == 2)
                {
                    userRock += 1;
                }
                else if (playerTool.GetHashCode() == 3)
                {
                    userPaper += 1;
                }
                else if (playerTool.GetHashCode() == 4)
                {
                    userLizard += 1;
                }
                else if (playerTool.GetHashCode() == 5)
                {
                    userSpock += 1;
                }

                // CheckWinner
                int buffer = wins;
                wins += GetWinner(playerTool, wins, rnd);
                if (wins == buffer)
                {
                    Console.WriteLine("Player Has Lost Against Computer with {0} against {1}" , playerTool  ,(Tools)rnd);
                    looses++;
                }
                Games++;
            

            }
     
        }

       static Tools ChooseTool(Tools tool , char selectedTool)
        {
            switch(selectedTool)
            {

                
                case 'S':
                case 's':
                
                    {
                        return Tools.Scissor;   
                        
                    }

                case 'R':
                case 'r':
                    {
                        return Tools.Rock;
                    }

                case 'P':
                case 'p':

                    {
                        return Tools.Paper;

                    }

                case 'L':
                case 'l':
                    {
                        return Tools.Lizard;
                    }

                case 'Z':
                case 'z':
                    {
                        return Tools.Spock;
                    }

                default:
                    Console.WriteLine("Falsche Eingabe");
                    System.Threading.Thread.Sleep(1500);
                    return Tools.Count;




            }
            



        }

       static int GetWinner(Tools playerTool, int wins , int Enemy)
        {
            wins = 1;
            int Player = playerTool.GetHashCode();
            

            // Spieler Wählt Schere
            if(Player == 1)
            {
                if (Enemy == 3)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)3);
                    return wins;
                    
                }

                else if (Enemy == 4)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)4);
                    return wins;
                }

                return 0;
            }

            // Spieler Wählt Stein
            if (Player == 2)
            {
                if (Enemy == 4)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)4);
                    return wins;
                }

                else if (Enemy == 1)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)1);
                    return wins;
                }
                return 0;
            }

            // Spieler ist Papier
            if (Player == 3)
            {
                if (Enemy==2)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)2);
                    return wins;
                }

               else if (Enemy==5)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)5);
                    return wins;
                }

                return 0;
            }

            //Spieler Ist Echse
            if (Player == 4)
            {
                if (Enemy == 5)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)5);
                    return wins;
                }

                else if (Enemy == 3)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)3);
                    return wins;
                }

                return 0;

            }
            // Spieler ist SPOCK
            if (Player == 5)
            {
                if (Enemy == 1)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)1);
                    return wins;
                }

                else if (Enemy == 2)
                {
                    Console.WriteLine("Player won with {0} against {1}", playerTool, (Tools)2);
                    return wins;
                }
                return 0;
            }
            // Gleichstand
            if (Player == Enemy)
            {
                Console.WriteLine("Gleischstand");
                return 0;
            }


            else return 0;

        }

        static Tools GetEasyTool(Tools tool, int userScissors, int userRock, int userPaper , int userLizard, int userSpock)
        {

                Dictionary<Tools, int> Dic = new Dictionary<Tools, int>();
                Dic.Add(Tools.Scissor, userScissors);
                Dic.Add(Tools.Rock, userRock);
                Dic.Add(Tools.Paper, userPaper);
                Dic.Add(Tools.Lizard, userLizard);
                Dic.Add(Tools.Spock, userSpock);

            int Player = 1;
            Random rand = new Random();
            int Zufall = rand.Next(1, 3);



            foreach (KeyValuePair<Tools,int> kvp in Dic)
            {
                if(kvp.Value >= userScissors)
                {
                    if(kvp.Value >= userRock)
                    {
                        if(kvp.Value >=userPaper)
                        {
                            if(kvp.Value >= userLizard)
                            {
                                if(kvp.Value >= userSpock)
                                {
                                    Player = kvp.Key.GetHashCode();
                                }
                            }
                        }
                    }
                }
            }



            // Spieler Wählt Schere
            if (Player == 1)
            {
               

                if (Zufall == 1)
                {
                    return Tools.Paper;


                }

                else if (Zufall == 2)
                {
                    return Tools.Lizard;
                }

                else
                    return Tools.Paper;

            }

            // Spieler Wählt Stein
            if (Player == 2)
            {
             

                if (Zufall == 1)
                {
                    return Tools.Lizard;


                }

                else if (Zufall == 2)
                {
                    return Tools.Scissor;
                }

                else
                    return Tools.Scissor;

            }

            // Spieler ist Papier
            if (Player == 3)
            {
                if (Zufall == 1)
                {
                    return Tools.Rock;


                }

                else if (Zufall == 2)
                {
                    return Tools.Spock;
                }

                else
                    return Tools.Rock;

            }

            //Spieler Ist Echse
            if (Player == 4)
            {
                if (Zufall == 1)
                {
                    return Tools.Spock;


                }

                else if (Zufall == 2)
                {
                    return Tools.Paper;
                }

                else
                    return Tools.Paper;

            }

            //Spieler ist Spock
            if (Player == 5)
            {

                if (Zufall == 1)
                {
                    return Tools.Scissor;


                }

                else if (Zufall == 2)
                {
                    return Tools.Rock;
                }

                else
                    return Tools.Scissor;

            }

            return Tools.Scissor;




 
        }

        static int CheckMode(int Wins, int Looses)
        {
            if (Wins+50 < Looses)
            {
                return 100;
            }

            if (Wins+40<Looses)
            {
                return 85;
            }

            if (Wins+30<Looses)
            {
                return 60;
            }

            if (Wins+20 < Looses)
            {
                return 50;
            }

            if(Wins+10<Looses)
            {
                return 30;
            }

            if (Wins+5 < Looses)
            {
                return 15;
            }

            return 0;



        }

       
    }
}
