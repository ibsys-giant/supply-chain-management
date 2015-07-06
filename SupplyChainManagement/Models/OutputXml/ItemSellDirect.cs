using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class ItemSellDirect
    {
        [XmlAttribute("article")]
        public int Article;

        [XmlAttribute("quantity")]
        public int Quantity = 0;

        [XmlAttribute("price")]
        public double Price = 0.0;

        [XmlAttribute("penalty")]
        public double Penalty = 0.0;
    }
}
