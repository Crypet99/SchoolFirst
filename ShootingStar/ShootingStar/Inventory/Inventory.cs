using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static ShootingStar.Inventory;

namespace ShootingStar
{
    internal class Inventory
    {



        // Inventar Liste -> Enum mit allen Einträgen Artikeln
        public enum Items
        {

            //Waffen
            Faust = 10,
            Schwert = 11,

            //Blöcke
            Erdblock = 20

        }

        #region InventarListen

        private List<Waffen> list_Waffen = new List<Waffen>();
        private List<Blöcke> list_Bloecke = new List<Blöcke>();

        #endregion

        #region InventoryFunktionen
        public void AddItem(Items enumValue, bool Special = false)
        {
            int value = (int)enumValue;
            string tvalue = value.ToString();

            // Waffen Klassen erstellen und Liste Hinzufügen 
            if (tvalue.Substring(0, 1) == "1")
            {
                switch (value)
                {
                    //Faust
                    case 10:
                        {
                            Fäuste Faust = null;
                            if (Special)
                                Faust = new Fäuste();
                            else
                                Faust = new Fäuste();

                            list_Waffen.Add(Faust);
                        }
                        break;

                    //Schwert
                    case 11:
                        {
                            Schwert schwert = null;
                            if (Special)
                                schwert = new Schwert(true);
                            else
                                schwert = new Schwert();

                            list_Waffen.Add(schwert);
                        }break;

                   



                }


            }

            //Blöcke Erstellen und Liste Hinzufügen
            if (tvalue.Substring(0, 1) == "2")
            {


                switch (value)
                {
                    //Schwert
                    case 20:
                        {
                            Erdblock erdblock = null;
                            if (Special)
                                erdblock = new Erdblock();
                            else
                                erdblock = new Erdblock();

                            list_Bloecke.Add(erdblock);
                        }
                        break;


                }
            }

        }
        
        public void ShowItems(Spieler spieler)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Inventar von : " + spieler.name + "\n---------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nWaffen\n---------------------------------");
            foreach (Waffen waffe in list_Waffen)
            {
                Console.WriteLine("-" + waffe.name);
            }
          

            Console.WriteLine("\nBlöcke\n---------------------------------");
            // Blöcke Zählen
            foreach (Blöcke block in list_Bloecke)
            {
                
                if(dic.ContainsKey(block.name))
                {
                    int value = dic[block.name];
                    value++;
                    dic[block.name] = value;
                }
                else if(!dic.ContainsKey(block.name))
                {
                    dic[block.name] = 0;
                }
            }
            foreach(var item in dic)
            {
                Console.WriteLine("Block : " + item.Key + " ("+item.Value+")");
            }




        }


        #endregion




    }
}
