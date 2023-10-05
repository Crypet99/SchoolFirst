using ShootingStar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShootingStar
{
     internal class Spieler : Interface
    {

      
        public Spieler(string iname, string idescription, int ihealth, int idamage , int iLevel) { name = iname; description = idescription; health = ihealth; damage = idamage;level = iLevel; }

        public Inventory InventoryManager = new Inventory();
        public string name { get; set; }
        public string description { get; set; }
        public int health { get; set; }
        public int damage {  get; set; }
        public int level { get; set; }


        string SavePathInventory = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\SaveInventory.txt";
        string SavePathPlayer = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\SavePlayer.txt";


        /// <summary>
        /// Checks All Items of Player XY and Shows them in Console
        /// </summary>

        public void OpenInventory()
        {
            InventoryManager.ShowItems(this);
        }
       
        /// <summary>
        /// Checks what Item is taken and creates it into the right inventory,also special Items are possible if Special True then Can change color and name manually or by user if
        /// </summary>
        /// <param name="enumValue"></param>
        /// <param name="special"></param>
        /// <param name="color"></param>
        /// <param name="name"></param>
        public int TakeItem(Inventory.Items enumValue , bool special = false , ConsoleColor color = ConsoleColor.Gray,string name = "" ,int Damage = 10 , int Lenght = 15)
        {

            return InventoryManager.AddItem(enumValue, special, color,name , Damage , Lenght);
            
        }
       
        /// <summary>
        /// Returns an Object of Class Waffen or Blöcken, need to be checked before Creation, if Item ID is included he gets this insteat
        /// </summary>
        /// <returns></returns>
        public object getItem(int ItemID = 0)
        {
           return InventoryManager.getItem(ItemID);
        }

        // Interface
        public string getStats() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Name : " + name);
            sb.AppendLine("Beschreibung : " + description);
            sb.AppendLine("Leben : " + health);
            sb.AppendLine("Schaden : " + damage);
            return sb.ToString();
        }
        public void Save(bool finished)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(name + ";" + description + ";" + health + ";" + damage + ";" + level + ";" + finished + ";");  

            File.WriteAllText(SavePathPlayer, sb.ToString());

            //string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            //File.WriteAllText(SavePathPlayer, json);

            InventoryManager.SaveInventory(SavePathInventory);

        }

        public bool LoadItems()
        {
            return InventoryManager.LoadGameData(SavePathInventory , SavePathPlayer);
        }

    }
}
