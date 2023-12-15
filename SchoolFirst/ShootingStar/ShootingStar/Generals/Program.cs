using Newtonsoft.Json;
using ShootingStar.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            bool bgame = true;
            int progress = 0;

            while (bgame)
            {

                Game game = new Game();
                Spieler spieler = PlayerSingleton.getInstance();

                foreach(var c in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.ForegroundColor = (ConsoleColor)c;
                    Console.WriteLine("\r\n\r\n\n\n\n\n\n\n\n\n\n███████╗██╗  ██╗ ██████╗  ██████╗ ████████╗██╗███╗   ██╗ ██████╗ ███████╗████████╗ █████╗ ██████╗ \r\n██╔════╝██║  ██║██╔═══██╗██╔═══██╗╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝╚══██╔══╝██╔══██╗██╔══██╗\r\n███████╗███████║██║   ██║██║   ██║   ██║   ██║██╔██╗ ██║██║  ███╗███████╗   ██║   ███████║██████╔╝\r\n╚════██║██╔══██║██║   ██║██║   ██║   ██║   ██║██║╚██╗██║██║   ██║╚════██║   ██║   ██╔══██║██╔══██╗\r\n███████║██║  ██║╚██████╔╝╚██████╔╝   ██║   ██║██║ ╚████║╚██████╔╝███████║   ██║   ██║  ██║██║  ██║\r\n╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝    ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝\r\n\r\n");
                    Functions.Sleep(200);
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                bool TutorialFinished = spieler.LoadItems();
                if (!TutorialFinished)
                    game.ChapterOne(progress);

                progress = 0;
                game.ChapterTwo(progress);




            }

        }
    }
}
