using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar.Health
{
    internal class Apple : HealthItems
    {
        Random random = new Random();
        public Apple() { Healthpoints = 10; ID = random.Next(1, 10000); name = "Apple"; }
    }
}
