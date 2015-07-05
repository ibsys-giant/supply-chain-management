using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class SellWish
    {
        [XmlElement("item")]
        public List<Item> Items = new List<Item>();
    }
}
