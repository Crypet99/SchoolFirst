using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Test
{



    // Spielfeld
    struct Spielfeld
    {

        public bool Rand_Links;
        public bool Rand_Rechts;
        public bool Feld_Besetzt;
        public bool feldSpieler;
        public bool feldGegner;
        public bool feldSchuss;


    }

    // Spieler Erstellen
    public class Spieler
    {
        public int spielerHoehe;
        public int spielerBreite;

    }

    // Schuss Erstellen 
    public class Schuss
    {
        public int schussHoehe = 0;
        public int schussBreite = 0;

    }

    struct Gegner
    {

        public int gegnerHoehe;
        public int gegnerBreite;

    }


    internal class Program
    {

        static void Main(string[] args)
        {



            char Eingabe;

            Eingabe = Console.ReadKey().KeyChar;

            

            // Variablen Deklarieren
            int Score = 0;
            int Highscore = 0;
            const byte Hoehe = 10;
            int Durchlauf = 0;
            const byte Breite = 20;
            const int gegner_spawn_Hohe = 0;
            int maxGegner = 5;
            int rnd_enemyspawn = 0;
            bool gameover = false;
            bool spielbeenden = false;
            short tics = 0;
            byte Schwierigkeit = 50;
            int Gegneranwesend = 0;
            Random rand = new Random();
            int eingabeMenue;
            byte erhoeheSchwierigkeit = 5;
            int erhoeheGegneranzahl = 1;
            int Runs_LVL = 0;
            int Runs_Enemy = 0;

            Spielfeld[,] Spielfeld = new Spielfeld[Hoehe, Breite];
            Spieler Spieler = new Spieler();
            Schuss Schuss = new Schuss();


            // Gegner Initialisieren
            rnd_enemyspawn = rand.Next(1, maxGegner);
            Gegner[] gegner = new Gegner[rnd_enemyspawn];
            for (int i = 0; i < rnd_enemyspawn - 1; i++)
            {
                bool gegnerplaced = false;

                if (Gegneranwesend < maxGegner && Gegneranwesend < rnd_enemyspawn)
                {
                    Gegneranwesend++;


                    do
                    {

                        int a = rand.Next(2, 17);
                        if (Spielfeld[gegner_spawn_Hohe, a].feldGegner == false)
                        {
                            gegner[i].gegnerBreite = a;
                            gegner[i].gegnerHoehe = gegner_spawn_Hohe;
                            Spielfeld[gegner_spawn_Hohe, a].feldGegner = true;
                            Spielfeld[gegner_spawn_Hohe, a].Feld_Besetzt = true;
                            gegnerplaced = true;
                        }



                    } while (gegnerplaced == false);
                    gegnerplaced = false;
                }


            }





            // Spieler Initialisieren
            Spieler.spielerBreite = Breite / 2 - 1;
            Spieler.spielerHoehe = 9;
            Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].feldSpieler = true;
            Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].Feld_Besetzt = true;

            // Nicht besetzte Felder auf false setzten
            for (int i = 0; i < Hoehe; i++)
            {
                for (int j = 0; j < Breite; j++)
                {
                    if (Spielfeld[i, j].Feld_Besetzt != true)
                    {
                        Spielfeld[i, j].Feld_Besetzt = false;

                    }
                }
            }

            // Spielfeld Rand Initialisieren
            {
                // Rand Links
                {
                    Spielfeld[0, 0].Rand_Links = true;
                    Spielfeld[1, 0].Rand_Links = true;
                    Spielfeld[2, 0].Rand_Links = true;
                    Spielfeld[3, 0].Rand_Links = true;
                    Spielfeld[4, 0].Rand_Links = true;
                    Spielfeld[5, 0].Rand_Links = true;
                    Spielfeld[6, 0].Rand_Links = true;
                    Spielfeld[7, 0].Rand_Links = true;
                    Spielfeld[8, 0].Rand_Links = true;
                    Spielfeld[9, 0].Rand_Links = true;


                }

                // Rand Rechts
                {
                    Spielfeld[0, 19].Rand_Rechts = true;
                    Spielfeld[1, 19].Rand_Rechts = true;
                    Spielfeld[2, 19].Rand_Rechts = true;
                    Spielfeld[3, 19].Rand_Rechts = true;
                    Spielfeld[4, 19].Rand_Rechts = true;
                    Spielfeld[5, 19].Rand_Rechts = true;
                    Spielfeld[6, 19].Rand_Rechts = true;
                    Spielfeld[7, 19].Rand_Rechts = true;
                    Spielfeld[8, 19].Rand_Rechts = true;
                    Spielfeld[9, 19].Rand_Rechts = true;

                }
            }


            // Spiel Intro
            for (int i = 0; i < 3; i++)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tSpace Invaders");
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tSpace Invaders");
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tSpace Invaders");
                System.Threading.Thread.Sleep(500);
                Console.Clear();



            }


            // Menue Schleifen
            while (spielbeenden == false)
            {
                Console.Clear();

                Console.WriteLine("Willkomen bei "); Console.ForegroundColor = ConsoleColor.Red; Console.Write("Space Invaders"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n----------------------------------------------------");

                Console.WriteLine("1. Spiel Starten");
                Console.WriteLine("2. Infos");
                Console.WriteLine("3. Beenden Starten");
                Console.WriteLine("4. Highscore");
                eingabeMenue = Convert.ToInt32(Console.ReadLine());

                switch (eingabeMenue)
                {
                    // Spiel Starten
                    case 1:
                        do
                        {
                            Console.Clear();



                            // Fehlende Gegner Zuweisen
                            int fehlendeGegner = maxGegner - Gegneranwesend;
                            Array.Resize(ref gegner, gegner.Length + fehlendeGegner);

                            if (fehlendeGegner > 0)
                            {
                                Gegneranwesend = Gegneranwesend + fehlendeGegner;
                            }

                            for (int i = 0; i < maxGegner - 1; i++)
                            {

                                if (Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].feldGegner == false && Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].Feld_Besetzt == false)
                                {
                                    bool gegnerplaced = false;

                                    do
                                    {

                                        int a = rand.Next(gegner_spawn_Hohe, Breite - 3);

                                        if (Spielfeld[gegner_spawn_Hohe, a].feldGegner == false)
                                        {
                                            gegner[i].gegnerBreite = a;
                                            gegner[i].gegnerHoehe = gegner_spawn_Hohe;
                                            Spielfeld[gegner_spawn_Hohe, a].feldGegner = true;
                                            Spielfeld[gegner_spawn_Hohe, a].Feld_Besetzt = true;
                                            gegnerplaced = true;
                                        }

                                    } while (gegnerplaced == false);

                                }





                            }


                            // Spielfeld Anzeigen
                            Zeige_Spiel(Spielfeld, Hoehe, Breite);


                            // Tastendruck erkennen / Bewegen + Schiessen
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.A)
                                {
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].feldSpieler = false;
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].Feld_Besetzt = false;

                                    if (Spieler.spielerBreite >= 2)
                                        Spieler.spielerBreite = Spieler.spielerBreite - 1;

                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].feldSpieler = true;
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].Feld_Besetzt = true;


                                }

                                else if (key.Key == ConsoleKey.D)
                                {
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].feldSpieler = false;
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].Feld_Besetzt = false;

                                    if (Spieler.spielerBreite <= 17)
                                        Spieler.spielerBreite = Spieler.spielerBreite + 1;

                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].feldSpieler = true;
                                    Spielfeld[Spieler.spielerHoehe, Spieler.spielerBreite].Feld_Besetzt = true;



                                }

                                else if (key.Key == ConsoleKey.Spacebar)
                                {

                                    Schuss.schussBreite = Spieler.spielerBreite;
                                    Schuss.schussHoehe = Spieler.spielerHoehe;

                                    for (int i = 8; i >= 0; i--)
                                    {


                                        Spielfeld[i, Spieler.spielerBreite].feldSchuss = true;
                                        Spielfeld[i, Spieler.spielerBreite].Feld_Besetzt = true;

                                        Console.Clear();
                                        Zeige_Spiel(Spielfeld, Hoehe, Breite);
                                        System.Threading.Thread.Sleep(1);


                                        Spielfeld[i, Spieler.spielerBreite].feldSchuss = false;
                                        Spielfeld[i, Spieler.spielerBreite].Feld_Besetzt = false;



                                    }

                                    System.Threading.Thread.Sleep(1);






                                }


                            }
                            System.Threading.Thread.Sleep(1);

                            // Teste ob getroffen
                            for (int i = 0; i < Gegneranwesend - 1; i++)
                            {



                                Durchlauf++;

                                if (gegner[i].gegnerBreite == Schuss.schussBreite)
                                {

                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].feldGegner = false;
                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].Feld_Besetzt = false;
                                    Schuss.schussBreite = 0;

                                    Score = Score + 10;


                                    Gegneranwesend--;

                                }


                            }



                            // Gegner Runtersetzen
                            if (tics > Schwierigkeit)
                            {

                                Runs_LVL++;
                                Runs_Enemy++;

                                tics = 0;
                                for (int i = 0; i < Gegneranwesend - 1; i++)
                                {

                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].Feld_Besetzt = false;
                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].feldGegner = false;
                                    gegner[i].gegnerHoehe = gegner[i].gegnerHoehe + 1;

                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].Feld_Besetzt = true;
                                    Spielfeld[gegner[i].gegnerHoehe, gegner[i].gegnerBreite].feldGegner = true;

                                    tics = 0;


                                }

                                if (Runs_LVL > 5)
                                {
                                    Schwierigkeit -= erhoeheSchwierigkeit;
                                    Runs_LVL = 0;
                                }

                                if (Runs_Enemy > 3)
                                {
                                    maxGegner = maxGegner + erhoeheGegneranzahl;
                                    Runs_Enemy = 0;
                                }
                            }

                            // Game Over
                            for (int i = 0; i < Gegneranwesend - 1; i++)
                            {



                                if (gegner[i].gegnerHoehe == Spieler.spielerHoehe)
                                {
                                    gameover = true;
                                }

                            }


                            // Teste Highscore 

                            if (Score > Highscore)
                            {
                                Highscore = Score;
                            }








                            Console.WriteLine(Score);
                            tics++;

                        } while (gameover == false);

                        Console.Clear();

                        // Spiel Outro
                        for (int i = 0; i < 3; i++)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tGame Over");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tGame Over");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\tGame Over");
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();



                        }

                        break;



                    // Infos
                    case 2:
                        Console.WriteLine("Erstellt von Crypet, am 06.10.2022 Arbeitsdauer ca 6-8h \n" +
                            "Anleitung : Raumschiff mit (A) und (D) nach links und rechts bewegen durch drücken der (Space) Taste wird geschossen" +
                            "Wichtig : Nicht für Epilektiker geeignet aufgrund der Bildwiederholungsrate Es wird keine Haftung übernommen :P");
                        Console.WriteLine("Zum Fortfahren Beliebige Taste drücken");
                        Console.ReadLine();
                        break;


                    case 3:
                        spielbeenden = true;
                        break;

                    case 4:
                        Console.WriteLine("Dein Highscore ist {0} und dein letzt erreichter score ist : {1}", Highscore, Score);

                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Bitte Gültige Ziffer eingeben");
                        break;







                }



            }












        }



        //Spielfeld Anzeigen
        static void Zeige_Spiel(Spielfeld[,] Spielfeld, int Hoehe, int Breite)
        {
            // Spielfeld
            for (int i = 0; i < Hoehe; i++)
            {

                for (int j = 0; j < Breite; j++)
                {


                    if (Spielfeld[i, j].Rand_Links == true)
                    {
                        Console.Write("|");
                        Spielfeld[i, j].Feld_Besetzt = true;
                    }


                    else if (Spielfeld[i, j].Rand_Rechts == true)
                    {

                        Console.Write("|");
                        Spielfeld[i, j].Feld_Besetzt = true;
                    }

                    else if (Spielfeld[i, j].Feld_Besetzt == false)
                    {

                        Console.Write(".");
                    }

                    else if (Spielfeld[i, j].Feld_Besetzt == true)
                    {
                        if (Spielfeld[i, j].feldSpieler == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("^");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (Spielfeld[i, j].feldSchuss == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (Spielfeld[i, j].feldGegner == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.White;
                        }



                    }

                }
                Console.WriteLine();

            }

        }



    }
}
