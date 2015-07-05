using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.InputXml
{
    public class CycleTimes
    {
        [XmlAttribute("startedorders")]
        public int StartedOrders;

        [XmlAttribute("waitingorders")]
        public int WaitingOrders;

        [XmlElement("order")]
        public List<Order> Orders;
    }
}
