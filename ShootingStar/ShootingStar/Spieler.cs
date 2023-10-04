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

      
        public Spieler(string iname, string idescription, int ihealth, int idamage) { name = iname; description = idescription; health = ihealth; damage = idamage; }

        public Inventory InventoryManager = new Inventory();
        public string name { get; set; }
        public string description { get; set; }
        public int health { get; set; }
        public int damage {  get; set; }

        string SavePathInventory = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\SaveInventory.txt";
        string SavePath = @"C:\Users\Student\Desktop\CHSU2\SchoolFirst\ShootingStar\SavePlayer.txt";


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
        public int TakeItem(Inventory.Items enumValue , bool special = false , ConsoleColor color = ConsoleColor.Gray,string name = "")
        {

            return InventoryManager.AddItem(enumValue, special, color,name);
            
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
        public void Save()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(name + ";" + description + ";" + health + ";" + damage + ";");

            File.WriteAllText(SavePath, sb.ToString());

            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(SavePath, json);

            InventoryManager.SaveInventory(SavePathInventory);

        }

        public bool LoadItems()
        {
            return InventoryManager.LoadInventory(SavePathInventory);
        }

    }
}
