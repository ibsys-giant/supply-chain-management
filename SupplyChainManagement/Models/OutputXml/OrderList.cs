using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class OrderList
    {
        [XmlElement("order")]
        public List<Order> Orders;
    }
}
