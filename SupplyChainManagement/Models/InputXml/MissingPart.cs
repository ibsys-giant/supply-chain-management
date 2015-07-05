using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.InputXml
{
    public class MissingPart
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlElement("waitinglist")]
        public List<WaitingList> WaitingLists = new List<WaitingList>();
    }
}
