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
        public readonly ORM DataSource;
        public readonly SimulatorClient Client;

        public SupplyChainManagement.Models.InputXml.PeriodResult PassedPeriodResult;

        public Dictionary<FinishedProduct, List<int>> Demands;
        public Dictionary<Product, int> WaitingList = new Dictionary<Product, int>();
        public Dictionary<Product, int> OrdersInWork = new Dictionary<Product, int>();
        public Dictionary<Workplace, double> AdditionalCapacityRequirements = new Dictionary<Workplace, double>();

        public MaterialPlanning MaterialPlanning;
        public CapacityPlanning CapacityPlanning;
        public ProcurementPlanning ProcurementPlanning;
        

        public SupplyChainPlanner(Uri endpoint, string username, string password, WebProxy proxy = null) 
        {
            DataSource = new ORM();
            Client = new SimulatorClient(endpoint, proxy);
            Client.Login(username, password);
        }

        public void Import(Uri uri) 
        {
            string xml = Client.ReadResult(uri);

            XmlSerializer serializer = new XmlSerializer(typeof(SupplyChainManagement.Models.InputXml.PeriodResult));

            using (TextReader reader = new StringReader(xml)) {
                PassedPeriodResult = (SupplyChainManagement.Models.InputXml.PeriodResult)serializer.Deserialize(reader);
            }

            foreach (var article in PassedPeriodResult.WarehouseStock.Articles) {
                var item = DataSource.GetItemById(article.Id);

                item.Stock = article.Amount;
                item.Value = article.Price;
            }
        }

        public void Plan(Dictionary<FinishedProduct, List<int>> demands, Dictionary<FinishedProduct, int> plannedWarehouseStocks)
        {
            Demands = demands;
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
                MaterialPlanning.CreateProductionOrders(finishedProduct, demands[finishedProduct][0], plannedWarehouseStocks[finishedProduct]);
            }
            
            // Do capacity planning
            CapacityPlanning = new CapacityPlanning(MaterialPlanning, AdditionalCapacityRequirements);
            CapacityPlanning.CreateWorkRequirements();

            // Do procurements planning
            ProcurementPlanning = new ProcurementPlanning(CapacityPlanning);
            ProcurementPlanning.CreateProcurementOrders(demands);

        }

        public void Export() 
        {

            var finalPlanning = ProcurementPlanning;
            var input = new SupplyChainManagement.Models.OutputXml.Input();

            var allItems = DataSource.GetAllItems();
            var finishedProducts = new List<FinishedProduct>(from item in allItems where item is FinishedProduct select item as FinishedProduct);

            foreach (var product in finishedProducts)
            {

                input.SellWish.Items.Add(new SupplyChainManagement.Models.OutputXml.Item
                {
                    Article = product.Id,
                    Quantity = Demands[product][0]
                });

                input.SellDirect.Items.Add(new SupplyChainManagement.Models.OutputXml.Item { 
                    Article = product.Id,
                    Penalty = 0.0,
                    Price = 0.0,
                    Quantity = 0
                });
            }


            foreach (var product in finalPlanning.ProductionOrders.Keys)
            {

                var order = finalPlanning.ProductionOrders[product];

                input.ProductionList.ProductionItems.Add(
                    new SupplyChainManagement.Models.OutputXml.Production
                    {
                        Article = product.Id,
                        Quantity = order
                    });

            }

            foreach (var workplace in finalPlanning.Overtime.Keys) {
                
                var overtime = (int) finalPlanning.Overtime[workplace];
                var shifts = finalPlanning.Shifts[workplace];

                input.WorkingTimeList.WorkingTime.Add(
                    new SupplyChainManagement.Models.OutputXml.WorkingTime
                    {
                        Overtime = overtime,
                        Shift = shifts,
                        Station = workplace.Id
                    });
            }

            XmlSerializer serializer = new XmlSerializer(typeof(SupplyChainManagement.Models.OutputXml.Input));

            String xml = null;
            using (TextWriter writer = new StringWriter())
            {

                serializer.Serialize(writer, input);
                xml = writer.ToString();
            }

            Client.WriteInputData(xml);

        }
    }
}
