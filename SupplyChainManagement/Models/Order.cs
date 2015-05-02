using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement
{
    public class Order<T> where T : Item
    {
        public T Item;
        public int Quantity;
    }
}
