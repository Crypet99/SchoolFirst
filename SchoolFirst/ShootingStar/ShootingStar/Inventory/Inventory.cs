using Newtonsoft.Json;
using ShootingStar.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ShootingStar.Inventory;
using static System.Net.Mime.MediaTypeNames;

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
            Erdblock = 20,


            // HealthItems
            Apple = 30,


            //Loot
            Ring = 40

        }

        #region InventarListen

        private List<Waffen> list_Waffen = new List<Waffen>();
        private List<Blöcke> list_Bloecke = new List<Blöcke>();
        private List<Loot> list_loot = new List<Loot>();
        #endregion

        #region InventoryFunktionen


        public int AddItem(Items enumValue, bool Special = false, ConsoleColor color = ConsoleColor.Gray, string name = "", int Damage = 10, int Length = 15)
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
                            return Faust.id;
                        }


                    //Schwert
                    case 11:
                        {
                            Schwert schwert = null;
                            if (Special)
                                schwert = new Schwert(true, color, name, Damage, Length);
                            else
                                schwert = new Schwert();

                            list_Waffen.Add(schwert);
                            return schwert.id;
                        }






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

            // Loot Erstellen und Hinzufügen
            if (tvalue.Substring(0, 1) == "4")
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
                            return Faust.id;
                        }


                    //Schwert
                    case 40:
                        {
                            Loot loot = null;
                            if (Special)
                                loot = new Loot(true, name);
                            else
                                loot = new Loot(Special, name );

                            list_loot.Add(loot);
                            return loot.ID;
                        }






                }


            }

            return 0;

        }


        public void ShowItems(Spieler spieler)
        {
            Dictionary<string, int> dicBlöcke = new Dictionary<string, int>();
            Dictionary<string, int> dicHealth = new Dictionary<string, int>();
            Dictionary<string, int> dicLoot = new Dictionary<string, int>();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Inventar von : " + spieler.name + "\n---------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nWaffen\n---------------------------------");
            foreach (Waffen waffe in list_Waffen)
            {
                Console.WriteLine("-" + waffe.name + " - ID : " + waffe.id);
            }


            Console.WriteLine("\nBlöcke\n---------------------------------");
            // Blöcke Zählen
            foreach (Blöcke block in list_Bloecke)
            {

                if (dicBlöcke.ContainsKey(block.name))
                {
                    int value = dicBlöcke[block.name];
                    value++;
                    dicBlöcke[block.name] = value;
                }
                else if (!dicBlöcke.ContainsKey(block.name))
                {
                    dicBlöcke[block.name] = 1;
                }
            }
            foreach (var item in dicBlöcke)
            {
                Console.WriteLine("Block : " + item.Key + " (" + item.Value + ")");
            }


           


            Console.WriteLine("\nLoot\n---------------------------------");
            // HealthItems Zählen
            foreach (Loot Item in list_loot)
            {

                if (dicLoot.ContainsKey(Item.name))
                {
                    int value = dicHealth[Item.name];
                    value++;
                    dicHealth[Item.name] = value;
                }
                else if (!dicLoot.ContainsKey(Item.name))
                {
                    dicLoot[Item.name] = 1;
                }
            }
            foreach (var item in dicLoot)
            {
                Console.WriteLine("Loot : " + item.Key + " (" + item.Value + ")");
            }
            Console.WriteLine("");




        }

        // Item Holen wenn ID mitgegeben dann sucht er in allen listen nach der ID und gibt diese Zurück
        public object getItem(int ItemID)
        {
            Waffen waffe = null;
            Blöcke block = null;
            Loot loot = null;
            string Value = "0";
            int latestChoice = 0;


            while (true)
            {
                if (latestChoice != 0)
                {
                    latestChoice = 0;
                    ItemID = 0;
                }

                Spieler spieler = PlayerSingleton.getInstance();

                if (ItemID == 0)
                {
                    spieler.OpenInventory();
                    Console.Write("Bitte eine Item_ID eingeben : ");
                }
                do
                {
                    if (ItemID != 0)
                        break;

                    Value = Console.ReadLine();

                    if (!Functions.IsNumeric(Value))
                        Console.WriteLine("Bitte eine Zahl eingeben");
                } while (!Functions.IsNumeric(Value));
                
                ItemID = Convert.ToInt32(Value == "0" ? Convert.ToString(ItemID) : Value);
                latestChoice = ItemID;

                foreach (Waffen w in list_Waffen)
                {
                    if (w.id == ItemID)
                    {
                        waffe = w;


                    }
                }

                foreach (Blöcke b in list_Bloecke)
                {
                    if (b.id == ItemID)
                    {
                        block = b;

                    }
                }


                foreach (Loot l in list_loot)
                {
                    if (l.ID == ItemID)
                    {
                        loot = l;


                    }
                }



                if (waffe != null)
                    return (object)waffe;
                else if (block != null)
                    return (object)block;
                else if (loot != null)
                    return (object)loot;

                else
                {
                    
                    if (Functions.SelectYesNo("\nEs wurde kein Item mit dieser ID gefunden, fortfahren ohne etwas auszuwählen?"))
                        return null;
                    else
                        continue;
                }

            }







        }


        public void SaveInventory(string SavePath)
        {


            string json = "";

            json = json + Environment.NewLine + "#";

            foreach (Waffen item in list_Waffen)
            {
                json = json + JsonConvert.SerializeObject(item, Formatting.Indented);
                json = json + ";";
            }

            json = json + Environment.NewLine + "#";
            foreach (Blöcke item in list_Bloecke)
            {
                json = json + JsonConvert.SerializeObject(item, Formatting.Indented);
                json = json + ";";
            }

            json = json + Environment.NewLine + "#";
            foreach (Loot item in list_loot)
            {
                json = json + JsonConvert.SerializeObject(item, Formatting.Indented);
                json = json + ";";
            }



            File.WriteAllText(SavePath, json);


        }

        public bool LoadGameData(string SavePathInventory , string SavePathPlayer)
        {
            Spieler spieler = PlayerSingleton.getInstance();
            string JsonInventory = File.ReadAllText(SavePathInventory);
            string JsonPlayer = File.ReadAllText(SavePathPlayer);

            if (JsonInventory != "")
            {
                list_loot.Clear();
                list_Bloecke.Clear();
                list_Waffen.Clear();
            }



            else
            {
                

                spieler.TakeItem(Inventory.Items.Faust);
                Functions.Sleep(100);
                spieler.TakeItem(Inventory.Items.Schwert);
                Functions.Sleep(100);

                spieler.TakeItem(Inventory.Items.Erdblock);
                spieler.TakeItem(Inventory.Items.Erdblock);
                spieler.TakeItem(Inventory.Items.Erdblock);
                spieler.TakeItem(Inventory.Items.Apple);
                spieler.TakeItem(Inventory.Items.Ring, false, ConsoleColor.Black, "Ring");
                return false;


            }


            // Lade Inventar
            string[] jsonClasses = JsonInventory.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string classes in jsonClasses)
            {
                string[] elements = classes.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in elements)
                {
                    string value = element;

                    if (value.Contains("Fäuste"))
                    {

                        Waffen waffe = JsonConvert.DeserializeObject<Waffen>(value);
                        list_Waffen.Add(waffe);
                    }

                    if (value.Contains("Schwert"))
                    {

                        Waffen waffe = JsonConvert.DeserializeObject<Waffen>(value);
                        list_Waffen.Add(waffe);
                    }

                    if (value.Contains("Erdblock"))
                    {

                        Blöcke blöcke = JsonConvert.DeserializeObject<Blöcke>(value);
                        list_Bloecke.Add(blöcke);
                    }


                    if (value.Contains("Loot"))
                    {

                        Loot loot = JsonConvert.DeserializeObject<Loot>(value);

                        list_loot.Add(loot);
                    }




                }
            }

            //Lade Spielerdaten
            if(JsonPlayer != "")
            {
                string[] Playerdata = JsonPlayer.Split(';');
                spieler.name = Playerdata[0];
                spieler.description = Playerdata[1];
                spieler.health = Convert.ToInt32(Playerdata[2]);
                spieler.damage = Convert.ToInt32(Playerdata[3]);
                spieler.level = Convert.ToInt32(Playerdata[4]);
                return Convert.ToBoolean(Playerdata[5]);
            }
            return false;


        }


        #endregion




    }
}
