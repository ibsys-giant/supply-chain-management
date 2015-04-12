using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    class ProcurementItem : Item
    {
        public int DiscountQuantity;
        public double OrderCosts;
        public double ProcureLeadTime;
        public double ProcureLeadTimeDeviation;
        public List<int> UsedInItemIds;
        public List<int> UsedInProducts;
    }
}
