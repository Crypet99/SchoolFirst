﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string selection = "";
            bool bgame = true;
            int progress = 0;

            while (bgame)
            {

                Game game = new Game();
                Console.Clear();
                Console.WriteLine("ShootingSTAR\n---------------------");
                Console.WriteLine("(S)piel Starten");
                Console.WriteLine("(E)instellungen");
                Console.WriteLine("(I)nfos (Vor Spielstart Lesen du Opfer)");
                Console.WriteLine("(B)eenden\n");

                do
                {
                    selection = (Console.ReadKey().KeyChar.ToString().ToLower());

                } while (!(selection == "s" || selection == "e" || selection == "b" || selection == "i"));


                switch (selection)
                {

                    case "s":
                        {
                            game.ChapterOne(progress);
                        }
                        break;

                    case "e":
                        {

                        }
                        break;

                    case "i":
                        {
                            Console.Clear();
                            Console.WriteLine("I -> Inventar Öffnen\nM -> Wo befindest du dich gerade\nBeliebige Taste zum Fortfahren...");
                            Console.ReadKey();
                        }
                        break;

                    case "b":
                        {
                            bgame = false;
                        }
                        break;






                }
            }

        }
    }
}