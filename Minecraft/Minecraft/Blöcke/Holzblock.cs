using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Blöcke
{
    internal class Holzblock : Basisblock
    {
        public Holzblock()
        {
            strengh = 200;
            blockColor = ConsoleColor.DarkGreen;
            blockName = "Holzblock";

        }

        public override int DestroyedBlock(Werkzeuge.Tools tools, string Template, int rarity = 1)
        {
            while (strengh > 0)
            {
                Thread.Sleep(150);

                switch (tools)
                {
                    case Werkzeuge.Tools.Hände:
                        {
                            Console.WriteLine("Schlägt Holz..");
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
                            strengh -= 50 * rarity;
                        }
                        break;

                    case Werkzeuge.Tools.Spitzhacke:
                        {
                            Console.WriteLine("Pling Ploing...");
                            strengh -= 30 * rarity;
                        }
                        break;


                }


            }
             base.DestroyedBlock(tools, blockName ,rarity);
            return rarity;

        }
    }
}
