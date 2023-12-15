using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    internal class Hände
    {
        public int EXP { get; set; } = 0;
        public int MaxEXP { get; set; } = 0;
        public int Level { get; set; } = 0;
        public bool CheckForLvlUP()
        {

            if (EXP >= MaxEXP)
            {
                int buffer = EXP -= MaxEXP;
                MaxEXP = MaxEXP * 2;
                EXP = buffer;
                return true;

            }
            return false;

        }


    }
}
