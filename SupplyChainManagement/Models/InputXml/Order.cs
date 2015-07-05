using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
{
    public class Order
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("orderperiod")]
        public int OrderPeriod;

        [XmlAttribute("mode")]
        public int Mode;

        [XmlAttribute("article")]
        public int Article;

        [XmlAttribute("amount")]
        public int Amount;

        [XmlAttribute("quantity")]
        public int Quantity;

        [XmlAttribute("cost")]
        public double Cost;

        [XmlAttribute("averageunitcosts")]
        public double AverageUnitCosts;

        [XmlAttribute("time")]
        public int Time;

        [XmlAttribute("materialcosts")]
        public double MaterialCosts;

        [XmlAttribute("ordercosts")]
        public double OrderCosts;

        [XmlAttribute("entirecosts")]
        public double EntireCosts;

        [XmlAttribute("piececosts")]
        public double PieceCosts;

        [XmlAttribute("starttime")]
        public string StartTime;

        [XmlAttribute("finishtime")]
        public string FinishTime;

        [XmlAttribute("cycletimemin")]
        public int CycleTimeMin;

        [XmlAttribute("cycletimefactor")]
        public double CycleTimeFactor;

        [XmlElement("batch")]
        public List<Batch> Batches;


    }
}
