using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
{
    public class Workplace
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("setupevents")]
        public int SetupEvents;

        [XmlAttribute("wageidletimecosts")]
        public double WageIdleTimeCosts;

        [XmlAttribute("wagecosts")]
        public double WageCosts;

        [XmlAttribute("machineidletimecosts")]
        public double MachineIdleTimeCosts;

        [XmlAttribute("timeneed")]
        public int TimeNeed;

    }
}
