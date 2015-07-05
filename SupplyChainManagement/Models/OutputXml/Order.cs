using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class Order
    {
        [XmlAttribute("article")]
        public int Article;

        [XmlAttribute("quantity")]
        public int Quantity;

        [XmlAttribute("modus")]
        public int Modus;
    }
}
