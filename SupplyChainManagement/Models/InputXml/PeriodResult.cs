using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.InputXml
{
    [XmlRoot("results")]
    public class PeriodResult
    {
        [XmlAttribute("game")]
        public int Game;

        [XmlAttribute("group")]
        public int Group;

        [XmlAttribute("period")]
        public int Period;

        [XmlElement("warehousestock")]
        public WarehouseStock WarehouseStock;

        [XmlElement("inwardstockmovement")]
        public InwardStockMovement InwardStockMovement;

        [XmlElement("futureinwardstockmovement")]
        public InwardStockMovement FutureInwardStockMovement;

        [XmlElement("idletimecosts")]
        public IdleTimeCosts IdleTimeCosts;

        [XmlElement("waitinglistworkstations")]
        public WaitingListWorkstations WaitingListWorkstations;

        [XmlElement("waitingliststock")]
        public WaitingListStock WaitingListStock;

        [XmlElement("ordersinwork")]
        public OrdersInWork OrdersInWork;

        [XmlElement("completedorders")]
        public CompletedOrders CompletedOrders;

        [XmlElement("cycletimes")]
        public CycleTimes CycleTimes;
    }
}
