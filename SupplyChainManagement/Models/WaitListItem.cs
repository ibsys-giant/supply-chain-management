using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Models
{
    public class WaitListItem
    {
        public int Period;
        public int Order;
        public Item Item;
        public int Amount;
        public int Timeneed;
        public int Lastbatch;
        public int Firstbatch;
    }
}
