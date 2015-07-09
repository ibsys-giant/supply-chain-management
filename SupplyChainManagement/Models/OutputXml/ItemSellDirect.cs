using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SupplyChainManagement.Models.OutputXml
{
    public class ItemSellDirect
    {
        [XmlAttribute("article")]
        public int Article;

        [XmlAttribute("quantity")]
        public int Quantity = 0;

        private double _Price = 0.0;

        [XmlAttribute("price")]
        public string Price
        {
            get
            {
                return _Price.ToString(); //String.Format("{0:0.0}", _Price);
            }
            set
            {
                _Price = double.Parse(value);
            }
        }

        private double _Penalty = 0.0;

        [XmlAttribute("penalty")]
        public string Penalty 
        {
            get
            {
                return _Penalty.ToString(); //String.Format("{0:0.0}", _Penalty);
            }
            set
            {
                _Penalty = double.Parse(value);
            }
        }
    }
}
