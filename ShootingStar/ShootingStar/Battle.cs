using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal static class Battle
    {
        public static void BattleTime(Spieler spieler, Gegner gegner , int round = 2)
        {
            BattleMenue(spieler, gegner);
            
        }


        private static void BattleMenue(Spieler spieler , Gegner genger , int round = 2)
        {

            int Round = round;

           
            ShowFighters();
            ShowTurn(Round++);

            //Bei Rundenwechsel aufrugen
            CharacterShowTogether();



        }


        #region BattleCharactersShowFunctions
        private static void CharacterVS()
        {
            Console.WriteLine("\r\n\r\n\t\t\t\t\t\t*******************\r\n\t\t\t\t\t\t*██╗   ██╗███████╗*\r\n\t\t\t\t\t\t*██║   ██║██╔════╝*\r\n\t\t\t\t\t\t*██║   ██║███████╗*\r\n\t\t\t\t\t\t*╚██╗ ██╔╝╚════██║*\r\n\t\t\t\t\t\t* ╚████╔╝ ███████║*\r\n\t\t\t\t\t\t*  ╚═══╝  ╚══════╝*\r\n\t\t\t\t\t\t*******************\r\n\r\n\t\t\t\t\t\t");

        }
        private static void CharacterShowTogether()
        {
            Console.WriteLine("                        __\r\t\t\t\t\t\t\t\t\t\t\t\t     ,\r\n                      /` ,\\__\r\t\t\t\t\t\t\t\t\t\t\t\t     |\\     ____\r\n                     |    ).-'\r\t\t\t\t\t\t\t\t\t\t\t\t     \\ \\.-./ .-' T\r\n                    / .--'\r\t\t\t\t\t\t\t\t\t\t\t\t      \\ _  _( /| | |\\\r\n                   / /\r\t\t\t\t\t\t\t\t\t\t\t\t    ) | .)(./ |  |  |\r\n     ,      _.==''`  \\\r\t\t\t\t\t\t\t\t\t\t\t\t      |   \\(   \\_|_/\r\n   .'(  _.='         |\r\t\t\t\t\t\t\t\t\t\t\t\t  (   |     \\    |\r\n  {   ``  _.='       |\r\t\t\t\t\t\t\t\t\t\t\t\t )    |  \\VvV    | (\r\n   {    \\`     ;    /\r\t\t\t\t\t\t\t\t\t\t\t\t      |  |\\,,\\   | \r\n    `.   `'=..'  .='\r\t\t\t\t\t\t\t\t\t\t\t\t    ) |  | ^^^   |    )\r\n      `=._    .='\r\t\t\t\t\t\t\t\t\t\t\t\t   (  |  |__     |   (\r        '-`\\\\`__\r\t\t\t\t\t\t\t\t\t\t\t\t )   /      `-. _|    )\r            `-._{\t\t\t\t\t\t\t\t\t\t\t\t(   /          /  `\\\r\n\t\t\t\t\t\t\t\t\t\t\t\t   /          ///_ |\r\n\t\t\t\t\t\t\t\t\t\t\t\t  /          (((-|'\r\n\t\t\t\t\t\t\t\t\t\t\t\t              ```|\"");

        }
        private static void CharacterShowMe()
        {
            Console.WriteLine("\t\t\t\t\t\t                        __\r\n\t\t\t\t\t\t                      /` ,\\__\r\n\t\t\t\t\t\t                     |    ).-'\r\n\t\t\t\t\t\t                    / .--'\r\n\t\t\t\t\t\t                   / /\r\n\t\t\t\t\t\t     ,      _.==''`  \\\r\n\t\t\t\t\t\t   .'(  _.='         |\r\n\t\t\t\t\t\t  {   ``  _.='       |\r\n\t\t\t\t\t\t   {    \\`     ;    /\r\n\t\t\t\t\t\t    `.   `'=..'  .='\r\n\t\t\t\t\t\t      `=._    .='\r\n\t\t\t\t\t\t        '-`\\\\`__\r\n\t\t\t\t\t\t            `-._{");
        }
        private static void CharacterShowEnemy()
        {
            Console.WriteLine("\t\t\t\t\t\t     ,\r\n\t\t\t\t\t\t     |\\     ____\r\n\t\t\t\t\t\t     \\ \\.-./ .-' T\r\n\t\t\t\t\t\t      \\ _  _( /| | |\\\r\n\t\t\t\t\t\t    ) | .)(./ |  |  |\r\n\t\t\t\t\t\t      |   \\(   \\_|_/\r\n\t\t\t\t\t\t  (   |     \\    |\r\n\t\t\t\t\t\t )    |  \\VvV    | (\r\n\t\t\t\t\t\t      |  |\\,,\\   | \r\n\t\t\t\t\t\t    ) |  | ^^^   |    )\r\n\t\t\t\t\t\t   (  |  |__     |   (\r\n\t\t\t\t\t\t )   /      `-. _|    )\r\n\t\t\t\t\t\t(   /          /  `\\\r\n\t\t\t\t\t\t   /          ///_ |\r\n\t\t\t\t\t\t  /          (((-|'\r\n\t\t\t\t\t\t              ```|");
        }
        private static void ShowFighters()
        {
            CharacterShowMe();
            Functions.Sleep(2500);
            Console.Clear();
            CharacterVS();
            Functions.Sleep(2500);
            Console.Clear();
            CharacterShowEnemy();
            Functions.Sleep(2500);
            Console.Clear();
        }

        public static void ShowTurn(int Round)
        {
            Console.Clear();
            Console.Write("\r\n\r\n██████╗  █████╗ ████████╗████████╗██╗     ███████╗████████╗██╗███╗   ███╗███████╗\r\n██╔══██╗██╔══██╗╚══██╔══╝╚══██╔══╝██║     ██╔════╝╚══██╔══╝██║████╗ ████║██╔════╝\r\n██████╔╝███████║   ██║      ██║   ██║     █████╗     ██║   ██║██╔████╔██║█████╗  \r\n██╔══██╗██╔══██║   ██║      ██║   ██║     ██╔══╝     ██║   ██║██║╚██╔╝██║██╔══╝  \r\n██████╔╝██║  ██║   ██║      ██║   ███████╗███████╗   ██║   ██║██║ ╚═╝ ██║███████╗\r\n╚═════╝ ╚═╝  ╚═╝   ╚═╝      ╚═╝   ╚══════╝╚══════╝   ╚═╝   ╚═╝╚═╝     ╚═╝╚══════╝\r\n\r\n");
            if (Round % 2 == 0)
                Console.WriteLine("\r\n\r\n██████╗ ██╗      █████╗ ██╗   ██╗███████╗██████╗     ████████╗██╗   ██╗██████╗ ███╗   ██╗\r\n██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██╔════╝██╔══██╗    ╚══██╔══╝██║   ██║██╔══██╗████╗  ██║\r\n██████╔╝██║     ███████║ ╚████╔╝ █████╗  ██████╔╝       ██║   ██║   ██║██████╔╝██╔██╗ ██║\r\n██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██╔══╝  ██╔══██╗       ██║   ██║   ██║██╔══██╗██║╚██╗██║\r\n██║     ███████╗██║  ██║   ██║   ███████╗██║  ██║       ██║   ╚██████╔╝██║  ██║██║ ╚████║\r\n╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝       ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝\r\n\r\n");
            else
                Console.WriteLine("\r\n\r\n███████╗███╗   ██╗███████╗███╗   ███╗██╗   ██╗    ████████╗██╗   ██╗██████╗ ███╗   ██╗\r\n██╔════╝████╗  ██║██╔════╝████╗ ████║╚██╗ ██╔╝    ╚══██╔══╝██║   ██║██╔══██╗████╗  ██║\r\n█████╗  ██╔██╗ ██║█████╗  ██╔████╔██║ ╚████╔╝        ██║   ██║   ██║██████╔╝██╔██╗ ██║\r\n██╔══╝  ██║╚██╗██║██╔══╝  ██║╚██╔╝██║  ╚██╔╝         ██║   ██║   ██║██╔══██╗██║╚██╗██║\r\n███████╗██║ ╚████║███████╗██║ ╚═╝ ██║   ██║          ██║   ╚██████╔╝██║  ██║██║ ╚████║\r\n╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝     ╚═╝   ╚═╝          ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝\r\n\r\n");
            Functions.Sleep(3500);
            Console.Clear();
        }

        #endregion
    }
}
