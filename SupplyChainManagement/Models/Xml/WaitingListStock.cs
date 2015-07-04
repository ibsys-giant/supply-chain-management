﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace SupplyChainManagement.Models.Xml
{
    public class WaitingListStock
    {
        [XmlElement("missingpart")]
        public List<MissingPart> MissingParts;
    }
}
