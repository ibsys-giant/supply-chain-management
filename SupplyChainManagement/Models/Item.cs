using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{

    enum ItemType { 
        E, K, P
    }

    abstract class Item
    {
        public int Id;
        public String Description;
        public double Value;
        public int Stock;

        public Item() { }
    }
}
