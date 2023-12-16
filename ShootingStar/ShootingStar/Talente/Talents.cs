using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Talents : iAttack
    {
        
        public int Damage;
        public string Talentname;
        public string TalentDescription;

        public virtual int getTalentStats()
        {
            return 0;
        }

        

    }
}
