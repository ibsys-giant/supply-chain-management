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
        public Dictionary<Item, int> ItemQuantities = new Dictionary<Item, int>();

        public Dictionary<Item, int> SummarizedItemQuantities {
            get {
                var level = -1;
                return _CalculateBillOfMaterial(ref level, 1, this, new Dictionary<Item, int>());
            }
        }

        private Dictionary<Item, int> _CalculateBillOfMaterial(ref int level, int parentQuantity, Item item, Dictionary<Item, int> bom) {


            var childs = item.ItemQuantities.Keys;
            
            foreach (Item child in childs) {

                var total = parentQuantity * item.ItemQuantities[child];
                if (bom.ContainsKey(child))
                {
                    bom[child] += total;
                }
                else 
                {
                    bom.Add(child, total);
                }

                level++;
                bom = child._CalculateBillOfMaterial(ref level, item.ItemQuantities[child], child, bom);
                level--;
            }
            return bom;
        }

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
