using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minecraft.Blöcke;

namespace Minecraft
{
    internal class Program
    {

        
          static void Main(string[] args)
        {
            Users playerOne= new Users();
            Hände Hand = new Hände();   
        

            

            do
            {

                Console.WriteLine("Mit Welchem Werkzeug Graben ?");
                Console.WriteLine("1.Hände\n2.Schaufel\n3.Axt\n4.Spitzhacke");
                Werkzeuge.Tools tools = (Werkzeuge.Tools)Convert.ToInt32(Console.ReadLine());
                GameStart(tools, playerOne,Hand); ;

                
                Console.WriteLine(tools.ToString());

                if(Hand.CheckForLvlUP())
                {
                    Console.WriteLine("Du bist nun Level {0}" , playerOne.Level);
                }
               

            }while(true);
            
            
            
        }


         public static void GameStart(Werkzeuge.Tools tools , Users Player, Hände hand)
        {
            Erdblock erdblock= new Erdblock();
            Holzblock holzblock = new Holzblock();
            Steinblock steinblock = new Steinblock();
            Random rnd = new Random();

            int RandomNumber  = rnd.Next(1,4);

            //RandomBlock
            switch(RandomNumber) 
            {
                case 1:  hand.EXP += (erdblock.DestroyedBlock(tools, erdblock.blockName)); break;
                case 2: Player.CurrentEXP +=(holzblock.DestroyedBlock(tools, erdblock.blockName)); break;
                case 3: Player.CurrentEXP +=(steinblock.DestroyedBlock(tools, erdblock.blockName)); break;


            }

            
            

        }

    }
}