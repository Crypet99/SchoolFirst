using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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

            public bool bEnemyType_Low;
            public bool bEnemyType_High;
            public bool bEnemyType_Mid;



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

            public int[] enemyPos_4 = new int[2] { 4, 39 };
            public int[] enemyPos_5 = new int[2] { 5, 39 };

            public int enemy_ID;
        }




        static void Main(string[] args)
        {


            // Werte Variablen
            int Points = 0;
            short jump_cooldown = 0;
            uint JumpTicks = 0;
            byte max_enemys = 3;
            const int gameWidth = 40;
            const int gameHeight = 7;
            uint gameTicks = 0;
            // 30 Leicht 1 Schwer ?
            uint gameMode = 30;
            uint Takt = 1000;

            //Strukturen
            Spielfeld[,] gamefield = new Spielfeld[gameHeight, gameWidth];

            // Klassen  Gegner
            Gegner[] enemyTypeLow = new Gegner[3];
            for (int i = 0; i < max_enemys; i++)
            {
                enemyTypeLow[i] = new Gegner();
                enemyTypeLow[i].enemy_ID = i;
            }

            // Klasse Spieler
            Player player = new Player();

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

                    gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = true;
                    gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = true;

                }
            }

            Console.WriteLine("Willkommen zu Shooting Star möchtest du das Spiel Starten ?");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("'S' Drücken um Spiel zu Starten");
            char menueEingabe = Console.ReadKey().KeyChar;

            switch (menueEingabe)
            {

                // Spiel Starten
                case 'S':
                case 's':
                    {

                        DisplayGame(gamefield, gameHeight, gameWidth, player, enemyTypeLow, Points);

                        // Game
                        while (true)
                        {

                            jump_cooldown =  Jump(gamefield, player, gameHeight, gameWidth, enemyTypeLow, Points ,  jump_cooldown);
                            gameTicks = SpawnEnemys(enemyTypeLow, gamefield, gameTicks, Takt, gameMode, gameHeight, gameWidth, player, Points);
                            gameTicks++;
                            
                            // Zähle Punkte
                            if (gameTicks % 2000 == 0)
                            {
                                Points++;
                            }
                            // Komentar

                           




                        }



                    }


            }




        } // Main Ende



        static void DisplayGame(Spielfeld[,] gamefield, int gameHeight, int gameWidth, Player player, Gegner[] enemyTypeLow, int Points)
        {
            Console.WriteLine("Deine Punkte : {0}", Points);

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

                    else if (gamefield[i, x].LeftHBottom == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(player.LeftHBottom);
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    else if (gamefield[i, x].RightHBottom == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(player.RightHBottom);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (gamefield[i, x].bEnemyType_Low == true)
                    {
                        Console.Write('|');
                    }





                    else
                        Console.Write(".");
                }
                Console.WriteLine("");
            }

        }

        static short Jump(Spielfeld[,] gamefield, Player player, int gameHeight, int gameWidth, Gegner[] enemyTypeLow, int Points ,  short jump_cooldown)
        {

          

            if (Console.KeyAvailable)
            {
                if (player.playerPosition_LeftF[0] <= 5)
                {
                    if (jump_cooldown >= 0 && jump_cooldown < 3)
                    {
                        

                        if (player.playerPosition_Head[0] >= 0)
                        {
                            ConsoleKeyInfo Key = Console.ReadKey(true);

                            if (Key.Key == ConsoleKey.W && player.playerPosition_Head[0] > 0)
                            {


                                InitializePlayerMovement(gamefield, player, -1);
                                Console.Clear();
                                DisplayGame(gamefield, gameHeight, gameWidth, player, enemyTypeLow, Points);
                              
                                
                                

                            }

                            



                            if (Key.Key == ConsoleKey.S && player.playerPosition_LeftF[0] < 5)
                            {
                                InitializePlayerMovement(gamefield, player, 1);

                                Console.Clear();
                                DisplayGame(gamefield, gameHeight, gameWidth, player, enemyTypeLow, Points); 
                            }
                        }

                        
                    }
                   
                    

                   
                }
                 
            }


            return 2;

        }

        static uint SpawnEnemys(Gegner[] enemyTypeLow, Spielfeld[,] gamefield, uint gameTicks, uint Takt, uint gameMode, int gameHeight, int gameWidth, Player player, int points)
        {


            if (gameTicks == Takt * 5)
            {

                gamefield[enemyTypeLow[0].enemyPos_5[0], enemyTypeLow[0].enemyPos_5[1]].bEnemyType_Low = false;
                gamefield[enemyTypeLow[0].enemyPos_4[0], enemyTypeLow[0].enemyPos_4[1]].bEnemyType_Low = false;

                enemyTypeLow[0].enemyPos_5[1]--;
                enemyTypeLow[0].enemyPos_4[1]--;

                gamefield[enemyTypeLow[0].enemyPos_5[0], enemyTypeLow[0].enemyPos_5[1]].bEnemyType_Low = true;
                gamefield[enemyTypeLow[0].enemyPos_4[0], enemyTypeLow[0].enemyPos_4[1]].bEnemyType_Low = true;

                gameTicks = Takt;

                // Delete Enemy and Restore at beginning
                if (enemyTypeLow[0].enemyPos_5[1] == 0 || enemyTypeLow[0].enemyPos_4[1] == 0)
                {
                    gamefield[enemyTypeLow[0].enemyPos_5[0], enemyTypeLow[0].enemyPos_5[1]].bEnemyType_Low = false;
                    gamefield[enemyTypeLow[0].enemyPos_4[0], enemyTypeLow[0].enemyPos_4[1]].bEnemyType_Low = false;

                    enemyTypeLow[0] = null;
                    enemyTypeLow[0] = new Gegner();
                }

                Console.Clear();
                DisplayGame(gamefield, gameHeight, gameWidth, player, enemyTypeLow, points);
                return gameTicks;

            }

            return gameTicks;




        }

        static bool isNumeric(string A)
        {
            return A.All(char.IsNumber);
        }

        static void InitializePlayerMovement(Spielfeld[,] gamefield, Player player, int Height)
        {
            gamefield[player.playerPosition_LeftF[0], player.playerPosition_LeftF[1]].playerPos_LeftF = false;
            gamefield[player.playerPosition_RightF[0], player.playerPosition_RightF[1]].playerPos_RightF = false;
            gamefield[player.playerPosition_Body[0], player.playerPosition_Body[1]].playerPos_Body = false;
            gamefield[player.playerPosition_Head[0], player.playerPosition_Head[1]].playerPos_Head = false;
            gamefield[player.playerPosition_LeftH[0], player.playerPosition_LeftH[1]].LeftHBottom = false;
            gamefield[player.playerPosition_RightH[0], player.playerPosition_RightH[1]].RightHBottom = false;


            player.playerPosition_LeftF[0] += Height;
            player.playerPosition_RightF[0] += Height;
            player.playerPosition_Body[0] += Height;
            player.playerPosition_Head[0] += Height;
            player.playerPosition_LeftH[0] += Height;
            player.playerPosition_RightH[0] += Height;

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
        }



    } // Class Ende
} // Namespace Ende
