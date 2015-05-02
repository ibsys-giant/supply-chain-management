using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.ItemManagement
{
    public class ProcuredItem : Item
    {
        public int DiscountQuantity;
        public double OrderCosts;
        public double ProcureLeadTime;
        public double ProcureLeadTimeDeviation;
    }
}
