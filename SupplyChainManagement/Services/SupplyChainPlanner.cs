using SupplyChainManagement.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;


using System.Net;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Services
{
    public class SupplyChainPlanner
    {
        public readonly SQLiteDataSource DataSource;
        public readonly SimulatorClient Client;

        public SupplyChainManagement.Models.Xml.PeriodResult PassedPeriodResult;

        public Dictionary<Product, int> WaitingList = new Dictionary<Product, int>();
        public Dictionary<Product, int> OrdersInWork = new Dictionary<Product, int>();
        public Dictionary<Workplace, double> AdditionalCapacityRequirements = new Dictionary<Workplace, double>();

        public MaterialPlanning MaterialPlanning;
        public CapacityPlanning CapacityPlanning;
        public ProcurementPlanning ProcurementPlanning;
        

        public SupplyChainPlanner(Uri endpoint, string username, string password, WebProxy proxy = null) 
        {
            DataSource = new SQLiteDataSource();
            Client = new SimulatorClient(endpoint, proxy);
            Client.Login(username, password);
        }

        public void Sync(int game, int group, int period) 
        {
            string xml = Client.ReadResult(game, group, period);

            XmlSerializer serializer = new XmlSerializer(typeof(SupplyChainManagement.Models.Xml.PeriodResult));

            using (TextReader reader = new StringReader(xml)) {
                PassedPeriodResult = (SupplyChainManagement.Models.Xml.PeriodResult)serializer.Deserialize(reader);
            }

            foreach (var article in PassedPeriodResult.WarehouseStock.Articles) {
                var item = DataSource.GetItemById(article.Id);

                item.Stock = article.Amount;
                item.Value = article.Price;

                DataSource.UpdateItem(ref item);
            }
        }

        public void Plan(List<Dictionary<FinishedProduct, int>> demands, Dictionary<FinishedProduct, int> plannedWarehouseStocks) {

            var allProducts = new List<Product>(from item in DataSource.GetAllItems() where item is Product select item as Product);
            var allFinishedProducts = new List<FinishedProduct>(from item in DataSource.GetAllItems() where item is FinishedProduct select item as FinishedProduct);

            // Retrieve workplaces from waiting list out of XML
            var waitingListWorkplaces = PassedPeriodResult.WaitingListWorkstations.Workplaces;

            foreach (var workplaceInformation in waitingListWorkplaces) {
                if (workplaceInformation.WaitingList != null) {
                    var product = DataSource.GetItemById(workplaceInformation.WaitingList.Item) as Product;
                    var workplace = DataSource.GetWorkplaceById(workplaceInformation.Id);
                    var itemJob = DataSource.GetItemJobByWorkplaceAndProduct(workplace, product);

                    if (WaitingList.ContainsKey(product))
                    {
                        WaitingList[product] += workplaceInformation.WaitingList.Amount;
                    }
                    else
                    {
                        WaitingList[product] = workplaceInformation.WaitingList.Amount;
                    }

                    
                    if (!AdditionalCapacityRequirements.ContainsKey(workplace)) 
                    {
                        AdditionalCapacityRequirements.Add(workplace, 0.0);
                    }

                    if (workplace.Id == 7) {
                        Console.WriteLine();
                    }

                    double additionalTime = (double) workplaceInformation.WaitingList.Amount;

                    AdditionalCapacityRequirements[workplace] += itemJob.ProductionTimePerPiece * additionalTime + itemJob.SetupTime;

                    var currentItemJob = itemJob;
                    while (currentItemJob.NextItemJob != null)
                    {
                        currentItemJob = currentItemJob.NextItemJob;
                        var currentWorkplace = currentItemJob.Workplace;

                        if (!AdditionalCapacityRequirements.ContainsKey(currentWorkplace))
                        {
                            AdditionalCapacityRequirements[currentWorkplace] = 0.0;
                        }

                        AdditionalCapacityRequirements[currentWorkplace] += currentItemJob.ProductionTimePerPiece * additionalTime + currentItemJob.SetupTime;
                    }
                }
            }


            // Retrieve workplaces from WIP list out of XML
            var workInProgressWorkplaces = PassedPeriodResult.OrdersInWork.Workplaces;

            foreach (var workplaceInformation in workInProgressWorkplaces)
            {
                var product = (Product) DataSource.GetItemById(workplaceInformation.Item);
                var workplace = DataSource.GetWorkplaceById(workplaceInformation.Id);
                var itemJob = DataSource.GetItemJobByWorkplaceAndProduct(workplace, product);

                if (OrdersInWork.ContainsKey(product))
                {
                    OrdersInWork[product] += workplaceInformation.Amount;
                }
                else
                {
                    OrdersInWork[product] = workplaceInformation.Amount;
                }
                
                if (!AdditionalCapacityRequirements.ContainsKey(workplace)) 
                {
                    AdditionalCapacityRequirements.Add(workplace, 0.0);
                }

                double additionalTime = (double)workplaceInformation.Amount;

                AdditionalCapacityRequirements[workplace] += itemJob.ProductionTimePerPiece * additionalTime;

                var currentItemJob = itemJob;
                while (currentItemJob.NextItemJob != null)
                {
                    currentItemJob = itemJob.NextItemJob;
                    var currentWorkplace = itemJob.Workplace;

                    if (!AdditionalCapacityRequirements.ContainsKey(currentWorkplace))
                    {
                        AdditionalCapacityRequirements[currentWorkplace] = 0.0;
                    }

                    AdditionalCapacityRequirements[currentWorkplace] += itemJob.ProductionTimePerPiece * additionalTime;
                }
            }


            // Do material planning

            MaterialPlanning = new MaterialPlanning(DataSource, WaitingList, OrdersInWork);

            foreach (var finishedProduct in allFinishedProducts) {
                MaterialPlanning.CreateProductionOrders(finishedProduct, demands[0][finishedProduct], plannedWarehouseStocks[finishedProduct]);
            }
            
            // Do capacity planning
            CapacityPlanning = new CapacityPlanning(MaterialPlanning, AdditionalCapacityRequirements);
            CapacityPlanning.CreateWorkRequirements();

            // Do procurements planning
            ProcurementPlanning = new ProcurementPlanning(CapacityPlanning);
            ProcurementPlanning.CreateProcurementOrders(demands);

        }
    }
}
