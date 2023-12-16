using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Standartschlag : Talents
    {
        public Standartschlag() { Damage = 5; Talentname = "BasisSchlag"; TalentDescription = "Ein Schlag für die Geschichte"; }

        public override int getTalentStats()
        {
            return Damage;
        }


    }
}
