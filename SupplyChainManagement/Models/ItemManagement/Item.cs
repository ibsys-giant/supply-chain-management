using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.ItemManagement
{
    public abstract class Item
    {
        public int Id;
        public String Description;
        public double Value;
        public int Stock;

        public Dictionary<Product, int> UsageQuantities = new Dictionary<Product, int>();
        public Product[] UsedInProducts {
            get {
                return new List<Product>(UsageQuantities.Keys).ToArray<Product>();
            }
        }

        public override string ToString()
        {
            string str = "";
            str += " #" + this.Id + " " + this.Description + "(" + this.GetType().Name + ")";
            return str;
        }
    }
}
