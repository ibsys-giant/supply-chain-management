using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.InputXml
{
    public class Article
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("amount")]
        public int Amount;

        [XmlAttribute("startamount")]
        public int StartAmount;

        [XmlAttribute("pct")]
        public double Pct;

        [XmlAttribute("price")]
        public double Price;

        [XmlAttribute("stockvalue")]
        public double StockValue;
    }
}
