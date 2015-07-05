using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class Item
    {
        [XmlAttribute("article")]
        public int Article;

        [XmlAttribute("quantity")]
        public int Quantity;

        [XmlAttribute("price")]
        public double Price;

        [XmlAttribute("penalty")]
        public double Penalty;
    }
}
