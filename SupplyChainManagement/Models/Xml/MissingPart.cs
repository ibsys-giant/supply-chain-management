using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models.Xml
{
    public class MissingPart
    {
        public int Id;
        public List<MissingPartWaitingListItem> WaitingListItems = new List<MissingPartWaitingListItem>();
    }
}
