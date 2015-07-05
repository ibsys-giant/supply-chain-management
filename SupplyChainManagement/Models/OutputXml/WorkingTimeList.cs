using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    
    public class WorkingTimeList
    {
        [XmlElement("workingtime")]
        public List<WorkingTime> WorkingTime = new List<WorkingTime>();
    }
}
