using Microsoft.VisualBasic;
using Minecraft.Blöcke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    internal class Steinblock : Basisblock
    {
        public Steinblock()
        {
            strengh = 300;
            blockColor = ConsoleColor.DarkGreen;

        }

        public override int DestroyedBlock(Werkzeuge.Tools tools, string Template ,int rarity = 1)
        {
            while (strengh > 0)
            {
                Thread.Sleep(150);

                switch (tools)
                {
                    case Werkzeuge.Tools.Hände:
                        {
                            Console.WriteLine("Schlägt Steine..");
                            strengh -= 10 * rarity;
                        }
                        break;

                    case Werkzeuge.Tools.Schaufel:
                        {
                            Console.WriteLine("Schaufelt...");
                            strengh -= 20 * rarity;
                        }
                        break;

                    case Werkzeuge.Tools.Axt:
                        {
                            Console.WriteLine("Hackt...");
                            strengh -= 30 * rarity;
                        }
                        break;

                    case Werkzeuge.Tools.Spitzhacke:
                        {
                            Console.WriteLine("Pling Ploing...");
                            strengh -= 50 * rarity;
                        }
                        break;


                }


            }

            base.DestroyedBlock(tools, "");
            return rarity;

        }


    }
}
