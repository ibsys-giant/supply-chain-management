using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.Xml
{
    public class FutureInwardStockOrder
    {
        public int Id;
        public int OrderPeriod;
        public int Mode;
        public int Article;
        public int Amount;
    }
}
