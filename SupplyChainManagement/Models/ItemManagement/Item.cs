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
        public Dictionary<Item, int> ChildItemQuantities = new Dictionary<Item, int>();

        public Dictionary<Item, int> BillOfMaterial {
            get {
                Dictionary<Item, int> bom = new Dictionary<Item, int>();
                
                foreach (Item child in ChildItemQuantities.Keys) {
                    bom.Add(child, ChildItemQuantities[child]);

                    Dictionary<Item, int> childBom = child.BillOfMaterial;

                    foreach (Item childChild in childBom.Keys) {
                        if (bom.ContainsKey(childChild))
                        {
                            bom[childChild] *= childBom[childChild];
                        }
                        else {
                            bom.Add(childChild, childBom[childChild]);
                        }
                    }
                }
                return bom;
            }
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
