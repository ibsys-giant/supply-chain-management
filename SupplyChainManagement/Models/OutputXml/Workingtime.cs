using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class WorkingTime
    {
        [XmlAttribute("station")]
        public int Station;

        [XmlAttribute("shift")]
        public int Shift;

        [XmlAttribute("overtime")]
        public int Overtime;
    }
}
