using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
{
    [XmlRoot("warehousestock")]
    public class WarehouseStock
    {
        [XmlElement("article")]
        public List<Article> Articles;
    }
}
