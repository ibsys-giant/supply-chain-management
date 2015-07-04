using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
{
    public class CompletedOrders
    {
        [XmlElement("order")]
        public List<Order> Orders;
    }
}
