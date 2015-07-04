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

        [XmlAttribute("period")]
        public int Period;

        [XmlAttribute("order")]
        public int Order;

        [XmlAttribute("batch")]
        public int Batch;

        [XmlAttribute("item")]
        public int Item;

        [XmlAttribute("amount")]
        public int Amount;

        [XmlElement("waitinglist")]
        public WaitingList WaitingList;
    }
}
