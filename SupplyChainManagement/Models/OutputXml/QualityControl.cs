using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class QualityControl
    {
        [XmlAttribute("type")]
        public string Type = "no";

        [XmlAttribute("losequantity")]
        public int LoseQuantity = 0;

        [XmlAttribute("delay")]
        public int Delay = 0;
    }
}
