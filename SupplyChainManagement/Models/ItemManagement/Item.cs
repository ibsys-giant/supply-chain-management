using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Data;    

namespace SupplyChainManagement.Models.ItemManagement
{
    public abstract class Item : DatabaseObject
    {
        public int Id;
        public String Description;
        public double Value;
        public int Stock;

        public Dictionary<Item, int> UsageQuantities = new Dictionary<Item, int>();
        public List<Product> UsedInProducts {
            get {
                return new List<Product>(from q in UsageQuantities where q.Key is Product select q.Key as Product);
            }
        }

        public override string ToString()
        {
            string str = "";
            str += " #" + this.Id + " " + this.Description + "(" + this.GetType().Name + ")";
            return str;
        }

        public override Dictionary<string, object> ToDictionary()
        {
            var dict = base.ToDictionary();
            dict["Id"] = Id;
            dict["Description"] = Description;
            dict["Value"] = Value;
            dict["Stock"] = Stock;
            return dict;
        }
    }
}
