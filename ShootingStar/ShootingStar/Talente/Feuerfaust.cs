using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Feuerfaust : Talents
    {

        public Feuerfaust() { Talentname = "Feuerfaust"; Damage = 15; TalentDescription = "Die Faust der Hölle"; }

        public int burnChance = 50;
        public int fireDamage = 6;

        public override int getTalentStats() // Was wenn burnschaden dauerhaft ? 
        {
            Random random = new Random();
            if (random.Next(0, 101) >= burnChance)
                return Damage + fireDamage;

            else
                return Damage;
        }
    }
}
