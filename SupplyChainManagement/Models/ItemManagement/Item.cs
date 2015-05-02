using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.ItemManagement
{
    public enum ItemType
    {
        E, K, P
    }

    public abstract class Item
    {
        public int Id;
        public String Description;
        public double Value;
        public int Stock;

        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            if (item == null) return false;
            return item.Id == this.Id;
        }

        public override string ToString()
        {
            string str = "";
            str += " #" + this.Id + " " + this.Description + "(" + this.GetType().Name + ")";
            return str;
        }
    }
}
