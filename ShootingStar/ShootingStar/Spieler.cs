using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingStar
{
     internal class Spieler
    {

      
        public Spieler(string iname, string idescription, int ihealth, int idamage) { name = iname; description = idescription; health = ihealth; damage = idamage; }

        public Inventory InventoryManager = new Inventory();
        public string name { get; set; }
        public string description { get; set; }
        public int health { get; set; }
        public int damage {  get; set; }

        public void OpenInventory()
        {
            InventoryManager.ShowItems(this);
        }

        public void TakeItem(Inventory.Items enumValue , bool special = false)
        {
            

            InventoryManager.AddItem(enumValue, special);
        }

        public void getItem()
        {
            InventoryManager.getItem();
        }

    }
}
