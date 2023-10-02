using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ShootingStar
{
     internal class PlayerSingleton
    {

        private PlayerSingleton() { }
        private static Spieler _instance;
        public static Spieler getInstance()
        {


            if (_instance == null)
                _instance = new Spieler("Crypet", "", 100, 10);

            return _instance;

        }

    }
}
