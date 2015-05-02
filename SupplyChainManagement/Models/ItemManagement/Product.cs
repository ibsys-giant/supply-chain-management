using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.ItemManagement
{
    public class Product : Item
    {
        public Dictionary<Item, int> ItemQuantities = new Dictionary<Item, int>();
        public Item[] Items
        {
            get
            {
                return new List<Item>(ItemQuantities.Keys).ToArray<Item>();
            }
        }

        public Product AddItem(Item item, int quantity) {
            if (ItemQuantities.ContainsKey(item)) 
            {
                ItemQuantities[item] = quantity;
            }
            else 
            {
                ItemQuantities.Add(item, quantity);
            }

            item.UsageQuantities.Add(this, quantity);

            return this;
        }
    }
}
