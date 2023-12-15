using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Blöcke
{
    internal class Erdblock : Basisblock
    {

        public Erdblock()
        {
            strengh = 100;
            blockColor = ConsoleColor.DarkGreen;
            blockName = "Erdblock";
            

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
                            Console.WriteLine("Gräbt...");
                            strengh -= 10 * rarity;
                        }
                        break;

                    case Werkzeuge.Tools.Schaufel:
                        {
                            Console.WriteLine("Schaufelt...");
                            strengh -= 50 * rarity;
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
                            Console.WriteLine("Schlägt...");
                            strengh -= 30 * rarity;
                        }
                        break;


                }


            }

            base.DestroyedBlock(tools , blockName );
            return rarity;

        }


    }
}
