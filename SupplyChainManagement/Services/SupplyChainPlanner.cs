using SupplyChainManagement.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

using SupplyChainManagement.Models.Xml;
using System.Net;

namespace SupplyChainManagement.Services
{
    public class SupplyChainPlanner
    {
        public readonly SQLiteDataSource DataSource;
        public readonly SimulatorClient Client;

        public PeriodResult PassedPeriodResult;
        

        public SupplyChainPlanner(Uri endpoint, string username, string password, WebProxy proxy) 
        {
            DataSource = new SQLiteDataSource();
            Client = new SimulatorClient(endpoint, proxy);
            Client.Login(username, password);
        }

        public void Sync(int game, int group, int period) 
        {
            string xml = Client.ReadResult(game, group, period);

            XmlSerializer serializer = new XmlSerializer(typeof(PeriodResult));

            using (TextReader reader = new StringReader(xml)) {
                PassedPeriodResult = (PeriodResult) serializer.Deserialize(reader);
            }
        }
    }
}
