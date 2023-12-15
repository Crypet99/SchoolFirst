using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft.Blöcke
{
    internal class Basisblock
    {


        protected int strengh;
        protected ConsoleColor blockColor;
        protected string _blockName { get; set; } = "";
        public string blockName
        {
            get { return _blockName; }
            set { _blockName = value; }
        }

        protected int _Rarity { get; set; } 
        public int Rarity
        {
            get { return _Rarity; }
            set { _Rarity = value; }
        }



        public virtual int DestroyedBlock(Werkzeuge.Tools tools, string Template , int rarity = 1)
        {
            Console.WriteLine("{0} wurde mit {1} zerstört",  blockName ,tools);  return rarity;
        }

    }
}
