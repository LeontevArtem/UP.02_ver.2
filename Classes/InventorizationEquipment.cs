using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class InventorizationEquipment
    {
        public int ID {  get; set; }
        public Inventory Inventory { get; set; }
        public Equipment Equipment { get; set;}
        public InventorizationEquipment(int ID,Inventory inventory,Equipment equipment)
        {
            this.ID = ID;
            this.Inventory = inventory;
            this.Equipment = equipment;
        }
    }
}
