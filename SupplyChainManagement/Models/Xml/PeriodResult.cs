using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
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

        public List<ArticleWarehouseStock> WarehouseStock = new List<ArticleWarehouseStock>();
        public List<InwardStockOrder> InwardStockMovement = new List<InwardStockOrder>();
        public List<InwardStockOrder> FutureInwardStockMovement = new List<InwardStockOrder>();
    }
}
