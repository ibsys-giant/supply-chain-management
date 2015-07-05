using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.InputXml
{
    public class Batch
    {
        [XmlElement("id")]
        public int Id;

        [XmlElement("amount")]
        public int Amount;

        [XmlElement("cycletime")]
        public int CycleTime;

        [XmlElement("cost")]
        public double Cost;
    }
}
