using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    [XmlRoot("input")]
    public class Input
    {

        [XmlElement("sellwish")]
        public SellWish SellWish = new SellWish();

        [XmlElement("selldirect")]
        public SellDirect SellDirect = new SellDirect();

        [XmlElement("orderlist")]
        public OrderList OrderList = new OrderList();

        [XmlElement("productionlist")]
        public ProductionList ProductionList = new ProductionList();

        [XmlElement("workingtimelist")]
        public WorkingTimeList WorkingTimeList = new WorkingTimeList();
    }
}
