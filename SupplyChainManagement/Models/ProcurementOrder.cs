using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Models
{
    public class ProcurementOrder
    {
        public enum OrderType { 
            NORMAL,
            FAST
        }
        public int Quantity;
        public OrderType Type;
    }
}
