using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    [XmlRoot("input")]
    public class Input
    {

        [XmlElement("sellwish")]
        public SellWish SellWish;

        [XmlElement("selldirect")]
        public SellDirect SellDirect;

        [XmlElement("orderlist")]
        public OrderList OrderList;
    }
}
