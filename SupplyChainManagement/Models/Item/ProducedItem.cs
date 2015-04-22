using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    public class ProducedItem : Item
    {
        public List<int> UsedInItemIds;
        public List<int> UsedInProducts;
    }
}
