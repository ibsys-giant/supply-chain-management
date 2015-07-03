using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.ItemManagement
{
    public class FinishedProduct : Product
    {

        public override Dictionary<string, object> ToDictionary()
        {
            var dict = base.ToDictionary();
            dict["Type"] = "FinishedProduct";
            return dict;
        }
    }
}
