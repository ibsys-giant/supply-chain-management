using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    public class OrderInWorkItem
    {
        public Workplace Workplace;
        public int Period;
        public int Order;
        public int Batch;
        public int Item;
        public int Amount;
        public int TimeNeed;
    }
}
