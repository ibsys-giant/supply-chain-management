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
        public List<Item> Items
        {
            get
            {
                return new List<Item>(ItemQuantities.Keys);
            }
        }
    }
}
