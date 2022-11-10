using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar_1YA_CHSU
{
    internal class Program
    {
        // Spielfeld
        struct Spielfeld
        {

            public bool Rand_Links;
            public bool Rand_Rechts;
            public bool Rand_Unten;
            public bool playerPos_LeftF;
            public bool playerPos_RightF;
            public bool playerPos_Body;
            public bool playerPos_Head;
            public bool LeftHBottom;
            public bool RightHBottom;
           


        }

        class Player
        {
            public int[] playerPosition_LeftF = new int[2] { 5, 4 };
            public int[] playerPosition_RightF = new int[2] { 5, 6 };
            public int[] playerPosition_LeftH = new int[2] { 4, 4 };
            public int[] playerPosition_RightH = new int[2] { 4, 6 };
            public int[] playerPosition_Body = new int[2] { 4, 5 };
            public int[] playerPosition_Head = new int[2] { 3, 5 };

            public char LeftF = '/';
            public char RightF = '\\';
            public char Body = '|';
            public char Head = 'O';
            public char LeftHBottom = '/';
            public char RightHBottom = '\\';
            


        }
        class Gegner
        {
            public int[] enemyPos_0 = new int[2] { 0, 39 };
            public int[] enemyPos_1 = new int[2] { 1, 39 };
            public int[] enemyPos_2 = new int[2] { 2, 39 };
            public int[] enemyPos_3 = new int[2] { 3, 39 };
            public int[] enemyPos_4 = new int[2] { 4, 39 };
            public int[] enemyPos_5 = new int[2] { 5, 39 };
        }




        static void Main(string[] args)
        {
            // Klassen
            Gegner enemyTypeLow = new Gegner();
           
            Player player = new Player();

            // Werte Variablen
            ushort field_enemys = 0;
            const int gameWidth = 40;
            const int gameHeight = 7;

            //Strukturen
            Spielfeld[,] gamefield = new Spielfeld[gameHeight, gameWidth];

            // Spielfeld Rand Initialisieren
            {

                // Rand Links
                {
                    gamefield[0, 0].Rand_Links = true;
                    gamefield[1, 0].Rand_Links = true;
                    gamefield[2, 0].Rand_Links = true;
                    gamefield[3, 0].Rand_Links = true;
                    gamefield[4, 0].Rand_Links = true;
                    gamefield[5, 0].Rand_Links = true;
                    gamefield[6, 0].Rand_Links = true;

                }

                // Rand Rechts
                {
                    gamefield[0, gameWidth - 1].Rand_Rechts = true;
                    gamefield[1, gameWidth - 1].Rand_Rechts = true;
                    gamefield[2, gameWidth - 1].Rand_Rechts = true;
                    gamefield[3, gameWidth - 1].Rand_Rechts = true;
                    gamefield[4, gameWidth - 1].Rand_Rechts = true;
                    gamefield[5, gameWidth - 1].Rand_Rechts = true;
                    gamefield[6, gameWidth - 1].Rand_Rechts = true;

                }

                // Rand Unten
                {

                    for (int i = 0; i < gameWidth - 1; i++)
                    {

                        gamefield[6, i].Rand_Unten = true;
                    }


                }
                // Spieler
                {
                    gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = true;
                    gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = true;
                    gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = true;
                    gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = true;

                    gamefield[player.playerPosition_LeftH[0],player.playerPosition_LeftH[1]].LeftHBottom = true;
                    gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = true;

                }
            }

            DisplayGame(gamefield, gameHeight, gameWidth, player);

            // Game
            while (true)
            {
                Jump(gamefield, player, gameHeight, gameWidth);
            } //Enemy Tool

        } // Main Ende



        static void DisplayGame(Spielfeld[,] gamefield, int gameHeight, int gameWidth, Player player)
        {
            for (int i = 0; i < gameHeight; i++)
            {
                for (int x = 0; x < gameWidth; x++)

                {
                    if (gamefield[i, x].Rand_Links == true)
                        Console.Write("|");

                    else if (gamefield[i, x].Rand_Rechts == true)
                    {
                        Console.Write('|');
                    }

                    else if (gamefield[i, x].Rand_Unten == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("_");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    else if (gamefield[i, x].playerPos_LeftF == true)
                    {
                        Console.Write(player.LeftF);
                    }
                    else if (gamefield[i, x].playerPos_RightF == true)
                    {
                        Console.Write(player.RightF);
                    }

                    else if (gamefield[i, x].playerPos_Body == true)
                    {
                        Console.Write(player.Body);
                    }
                    else if (gamefield[i, x].playerPos_Head == true)
                    {
                        Console.Write(player.Head);
                    }
                    // Works

                    else if (gamefield[i,x].LeftHBottom == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(player.LeftHBottom);
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    else if (gamefield[i,x].RightHBottom == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(player.RightHBottom);
                        Console.ForegroundColor = ConsoleColor.White;

                       
                    }





                    else
                        Console.Write(".");
                }
                Console.WriteLine("");
            }

        }

        static void Jump(Spielfeld[,] gamefield, Player player, int gameHeight, int gameWidth)
        {
            if (Console.KeyAvailable)
            {
                if (player.playerPosition_LeftF[0] <= 5)
                {
                    if (player.playerPosition_Head[0] >= 0)
                    {
                        ConsoleKeyInfo Key = Console.ReadKey(true);

                        if (Key.Key == ConsoleKey.W && player.playerPosition_Head[0] > 0)
                        {
                            gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = false;
                            gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = false;
                            gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = false;
                            gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = false;
                            gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = false;
                            gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = false;


                            player.playerPosition_LeftF[0]--;
                            player.playerPosition_RightF[0]--;
                            player.playerPosition_Body[0]--;
                            player.playerPosition_Head[0]--;
                            player.playerPosition_LeftH[0]--;
                            player.playerPosition_RightH[0]--;

                            gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = true;
                            gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = true;
                            gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = true;
                            gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = true;
                            gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = true;
                            gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = true;

                            if (player.playerPosition_LeftH[0] == 3)
                            {
                                player.LeftHBottom = '-';
                                player.RightHBottom = '-';
                            }
                            if (player.playerPosition_LeftH[0] <3 )
                            {
                                player.LeftHBottom ='\\';
                                player.RightHBottom = '/';
                            }
                            if (player.playerPosition_LeftH[0] > 3)
                            {
                                player.LeftHBottom = '/';
                                player.RightHBottom = '\\';
                            }


                            Console.Clear();
                            DisplayGame(gamefield, gameHeight, gameWidth, player);
                        }

                        if (Key.Key == ConsoleKey.S && player.playerPosition_LeftF[0] < 5)
                        {
                            gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = false;
                            gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = false;
                            gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = false;
                            gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = false;
                            gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = false;
                            gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = false;


                            player.playerPosition_LeftF[0]++;
                            player.playerPosition_RightF[0]++;
                            player.playerPosition_Body[0]++;
                            player.playerPosition_Head[0]++;
                            player.playerPosition_LeftH[0]++;
                            player.playerPosition_RightH[0]++;

                            gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = true;
                            gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = true;
                            gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = true;
                            gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = true;
                            gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = true;
                            gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = true;

                            if (player.playerPosition_LeftH[0] == 3)
                            {
                                player.LeftHBottom = '-';
                                player.RightHBottom = '-';
                            }
                            if (player.playerPosition_LeftH[0] < 3)
                            {
                                player.LeftHBottom = '\\';
                                player.RightHBottom = '/';
                            }
                            if (player.playerPosition_LeftH[0] > 3)
                            {
                                player.LeftHBottom = '/';
                                player.RightHBottom = '\\';
                            }

                                Console.Clear();
                            DisplayGame(gamefield, gameHeight, gameWidth, player);
                        }
                    }
                }

            }


        }

        static int SpawnEnemys(Gegner enemyType_Low)
        {


            return 0;
        }

    } // Class Ende
} // Namespace Ende
