using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement
{
    public class DataSourceMock : DataSource
    {
        private Dictionary<int, Item> _Items = new Dictionary<int,Item>();
        public Dictionary<int, Item> Items {
            get {
                return _Items;
            }
        }

        private Dictionary<int, Workplace> _Workplaces = new Dictionary<int, Workplace>();
        public Dictionary<int, Workplace> Workplaces
        {
            get
            {
                return _Workplaces;
            }
        }

        private Dictionary<int, ItemJob> _ItemJobs = new Dictionary<int, ItemJob>();
        public Dictionary<int, ItemJob> ItemJobs
        {
            get
            {
                return _ItemJobs;
            }
        }

        public DataSourceMock() {

            // Create mock items

            AddNewItem(new ProductItem { Id = 1, Description = "Children's Bicycle", Value = 156.13, Stock = 100 });
            AddNewItem(new ProductItem { Id = 2, Description = "Ladies Bicycle", Value = 163.33, Stock = 100 });
            AddNewItem(new ProductItem { Id = 3, Description = "Men's Bicycle", Value = 165.08, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 4, Description = "Rear wheel group", Value = 40.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 5, Description = "Rear wheel group", Value = 39.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 6, Description = "Rear wheel group", Value = 40.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 7, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 8, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 9, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 10, Description = "Mudguard rear", Value = 12.40, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 11, Description = "Mudguard rear", Value = 14.65, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 12, Description = "Mudguard rear", Value = 14.65, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 13, Description = "Mudguard front", Value = 12.40, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 14, Description = "Mudguard front", Value = 14.65, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 15, Description = "Mudguard front", Value = 14.65, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 16, Description = "Handle complete", Value = 7.02, Stock = 300 });
            AddNewItem(new ProducedItem { Id = 17, Description = "Saddle complete", Value = 1.16, Stock = 300 });
            AddNewItem(new ProducedItem { Id = 18, Description = "Frame", Value = 13.15, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 19, Description = "Frame", Value = 14.35, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 20, Description = "Frame", Value = 15.55, Stock = 100 });
            AddNewItem(new ProcurementItem { Id = 21, Description = "Chain", Value = 5.0, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.8, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProcurementItem { Id = 22, Description = "Chain", Value = 6.5, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProcurementItem { Id = 23, Description = "Chain", Value = 6.5, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProcurementItem { Id = 24, Description = "Nut 3/8 inch", Value = 0.06, Stock = 6100, OrderCosts = 100.0, ProcureLeadTime = 3.2, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 25, Description = "Washer 3/8 inch", Value = 0.06, Stock = 3600, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProducedItem { Id = 26, Description = "Pedal complete", Value = 10.5, Stock = 300 });
            AddNewItem(new ProcurementItem { Id = 27, Description = "Screw 3/8 inch", Value = 0.1, Stock = 1800, OrderCosts = 75.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProcurementItem { Id = 28, Description = "Tube 3/4 inch", Value = 1.2, Stock = 4500, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProducedItem { Id = 29, Description = "Front wheel compl.", Value = 69.29, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 30, Description = "Frame and wheels", Value = 127.53, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 31, Description = "Bicycle w/o wheels", Value = 144.42, Stock = 100 });
            AddNewItem(new ProcurementItem { Id = 32, Description = "Paint", Value = 0.75, Stock = 2700, OrderCosts = 50.0, ProcureLeadTime = 2.1, ProcureLeadTimeDeviation = 0.5 });
            AddNewItem(new ProcurementItem { Id = 33, Description = "Rim compl.", Value = 22.0, Stock = 900, OrderCosts = 75.0, ProcureLeadTime = 1.9, ProcureLeadTimeDeviation = 0.5 });
            AddNewItem(new ProcurementItem { Id = 34, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 35, Description = "Taper sleeve", Value = 1.0, Stock = 3600, OrderCosts = 75.0, ProcureLeadTime = 2.2, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProcurementItem { Id = 36, Description = "Free wheel", Value = 8.0, Stock = 900, OrderCosts = 100.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.1 });
            AddNewItem(new ProcurementItem { Id = 37, Description = "Fork", Value = 1.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.5, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 38, Description = "Axle", Value = 1.5, Stock = 300, OrderCosts = 75.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProcurementItem { Id = 39, Description = "Sheet", Value = 1.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.5, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 40, Description = "Handle Bar", Value = 2.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProcurementItem { Id = 41, Description = "Nut 3/4 inch", Value = 0.06, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProcurementItem { Id = 42, Description = "Handle Grip", Value = 0.1, Stock = 1800, OrderCosts = 50.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 43, Description = "Saddle", Value = 5.0, Stock = 1900, OrderCosts = 75.0, ProcureLeadTime = 2.0, ProcureLeadTimeDeviation = 0.5 });
            AddNewItem(new ProcurementItem { Id = 44, Description = "Bar 1/2 inch", Value = 0.5, Stock = 2700, OrderCosts = 50.0, ProcureLeadTime = 1.0, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProcurementItem { Id = 45, Description = "Nut 1/4 inch", Value = 0.06, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 46, Description = "Screw 1/4 inch", Value = 0.1, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 47, Description = "Sprocket", Value = 3.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.41, ProcureLeadTimeDeviation = 0.1 });
            AddNewItem(new ProcurementItem { Id = 48, Description = "Pedal", Value = 1.5, Stock = 1800, OrderCosts = 75.0, ProcureLeadTime = 1.0, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProducedItem { Id = 49, Description = "Front wheel complete", Value = 64.64, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 50, Description = "Frame and wheels", Value = 120.63, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 51, Description = "Bicycle w/o pedals", Value = 137.47, Stock = 100});
            AddNewItem(new ProcurementItem { Id = 52, Description = "Rim compl.", Value = 22.0, Stock = 600, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.4 });
            AddNewItem(new ProcurementItem { Id = 53, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.2 });
            AddNewItem(new ProducedItem { Id = 54, Description = "Front wheel compl.", Value = 68.09, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 55, Description = "Frame and wheels", Value = 125.33, Stock = 100 });
            AddNewItem(new ProducedItem { Id = 56, Description = "Bicycle w/o pedals", Value = 142.67, Stock = 100 });
            AddNewItem(new ProcurementItem { Id = 57, Description = "Rim compl.", Value = 22.0, Stock = 600, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.3 });
            AddNewItem(new ProcurementItem { Id = 58, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.5 });
            AddNewItem(new ProcurementItem { Id = 59, Description = "Welding wires", Value = 0.15, Stock = 1800, OrderCosts = 50.0, ProcureLeadTime = 0.7, ProcureLeadTimeDeviation = 0.2 });

            // 1
            Items[1].ChildItemQuantities.Add(Items[21], 1);
            Items[1].ChildItemQuantities.Add(Items[24], 1);
            Items[1].ChildItemQuantities.Add(Items[27], 1);
            Items[1].ChildItemQuantities.Add(Items[26], 1);
            Items[1].ChildItemQuantities.Add(Items[51], 1);

            // 2
            Items[2].ChildItemQuantities.Add(Items[22], 1);
            Items[2].ChildItemQuantities.Add(Items[24], 1);
            Items[2].ChildItemQuantities.Add(Items[27], 1);
            Items[2].ChildItemQuantities.Add(Items[26], 1);
            Items[2].ChildItemQuantities.Add(Items[56], 1);

            // 3
            Items[3].ChildItemQuantities.Add(Items[23], 1);
            Items[3].ChildItemQuantities.Add(Items[24], 1);
            Items[3].ChildItemQuantities.Add(Items[27], 1);
            Items[3].ChildItemQuantities.Add(Items[26], 1);
            Items[3].ChildItemQuantities.Add(Items[31], 1);

            // 4
            Items[4].ChildItemQuantities.Add(Items[35], 2);
            Items[4].ChildItemQuantities.Add(Items[36], 1);
            Items[4].ChildItemQuantities.Add(Items[52], 1);
            Items[4].ChildItemQuantities.Add(Items[53], 36);

            // 5
            Items[5].ChildItemQuantities.Add(Items[35], 2);
            Items[5].ChildItemQuantities.Add(Items[36], 1);
            Items[5].ChildItemQuantities.Add(Items[57], 1);
            Items[5].ChildItemQuantities.Add(Items[58], 36);

            // 6
            Items[6].ChildItemQuantities.Add(Items[33], 1);
            Items[6].ChildItemQuantities.Add(Items[34], 36);
            Items[6].ChildItemQuantities.Add(Items[35], 2);
            Items[6].ChildItemQuantities.Add(Items[36], 1);

            // 7
            Items[7].ChildItemQuantities.Add(Items[35], 2);
            Items[7].ChildItemQuantities.Add(Items[37], 1);
            Items[7].ChildItemQuantities.Add(Items[38], 1);
            Items[7].ChildItemQuantities.Add(Items[52], 1);
            Items[7].ChildItemQuantities.Add(Items[53], 36);

            // 8
            Items[8].ChildItemQuantities.Add(Items[35], 2);
            Items[8].ChildItemQuantities.Add(Items[37], 1);
            Items[8].ChildItemQuantities.Add(Items[38], 1);
            Items[8].ChildItemQuantities.Add(Items[57], 1);
            Items[8].ChildItemQuantities.Add(Items[58], 36);

            // 9
            Items[9].ChildItemQuantities.Add(Items[33], 1);
            Items[9].ChildItemQuantities.Add(Items[34], 36);
            Items[9].ChildItemQuantities.Add(Items[35], 2);
            Items[9].ChildItemQuantities.Add(Items[37], 1);
            Items[9].ChildItemQuantities.Add(Items[38], 1);

            // 10
            Items[10].ChildItemQuantities.Add(Items[32], 1);
            Items[10].ChildItemQuantities.Add(Items[39], 1);

            // 11
            Items[11].ChildItemQuantities.Add(Items[35], 2);
            Items[11].ChildItemQuantities.Add(Items[36], 1);

            // 12
            Items[12].ChildItemQuantities.Add(Items[32], 1);
            Items[12].ChildItemQuantities.Add(Items[39], 1);

            // 13
            Items[13].ChildItemQuantities.Add(Items[32], 1);
            Items[13].ChildItemQuantities.Add(Items[39], 1);

            // 14
            Items[14].ChildItemQuantities.Add(Items[32], 1);
            Items[14].ChildItemQuantities.Add(Items[39], 1);

            // 15
            Items[15].ChildItemQuantities.Add(Items[32], 1);
            Items[15].ChildItemQuantities.Add(Items[39], 1);

            // 16
            Items[16].ChildItemQuantities.Add(Items[24], 1);
            Items[16].ChildItemQuantities.Add(Items[28], 1);
            Items[16].ChildItemQuantities.Add(Items[40], 1);
            Items[16].ChildItemQuantities.Add(Items[41], 1);
            Items[16].ChildItemQuantities.Add(Items[42], 2);

            // 17
            Items[17].ChildItemQuantities.Add(Items[43], 1);
            Items[17].ChildItemQuantities.Add(Items[44], 1);
            Items[17].ChildItemQuantities.Add(Items[45], 1);
            Items[17].ChildItemQuantities.Add(Items[46], 1);

            // 18
            Items[18].ChildItemQuantities.Add(Items[28], 3);
            Items[18].ChildItemQuantities.Add(Items[32], 1);
            Items[18].ChildItemQuantities.Add(Items[59], 2);

            // 19
            Items[19].ChildItemQuantities.Add(Items[28], 4);
            Items[19].ChildItemQuantities.Add(Items[32], 1);
            Items[19].ChildItemQuantities.Add(Items[59], 2);

            // 20
            Items[20].ChildItemQuantities.Add(Items[28], 5);
            Items[20].ChildItemQuantities.Add(Items[32], 1);
            Items[20].ChildItemQuantities.Add(Items[59], 2);

            // 21-25: Procurement parts

            // 26
            Items[26].ChildItemQuantities.Add(Items[44], 2);
            Items[26].ChildItemQuantities.Add(Items[47], 1);
            Items[26].ChildItemQuantities.Add(Items[48], 2);

            // 27-28: Procurement parts

            // 29
            Items[29].ChildItemQuantities.Add(Items[24], 2);
            Items[29].ChildItemQuantities.Add(Items[25], 2);
            Items[29].ChildItemQuantities.Add(Items[9], 1);
            Items[29].ChildItemQuantities.Add(Items[15], 1);
            Items[29].ChildItemQuantities.Add(Items[20], 1);

            // 30
            Items[30].ChildItemQuantities.Add(Items[24], 2);
            Items[30].ChildItemQuantities.Add(Items[25], 2);
            Items[30].ChildItemQuantities.Add(Items[6], 1);
            Items[30].ChildItemQuantities.Add(Items[12], 1);
            Items[30].ChildItemQuantities.Add(Items[29], 1);

            // 31
            Items[31].ChildItemQuantities.Add(Items[24], 1);
            Items[31].ChildItemQuantities.Add(Items[27], 1);
            Items[31].ChildItemQuantities.Add(Items[16], 1);
            Items[31].ChildItemQuantities.Add(Items[17], 1);
            Items[31].ChildItemQuantities.Add(Items[30], 1);

            // 32 - 48: Procurement parts

            // 49
            Items[49].ChildItemQuantities.Add(Items[24], 2);
            Items[49].ChildItemQuantities.Add(Items[25], 2);
            Items[49].ChildItemQuantities.Add(Items[7], 1);
            Items[49].ChildItemQuantities.Add(Items[13], 1);
            Items[49].ChildItemQuantities.Add(Items[18], 1);

            // 50
            Items[50].ChildItemQuantities.Add(Items[24], 2);
            Items[50].ChildItemQuantities.Add(Items[25], 2);
            Items[50].ChildItemQuantities.Add(Items[4], 1);
            Items[50].ChildItemQuantities.Add(Items[10], 1);
            Items[50].ChildItemQuantities.Add(Items[49], 1);

            // 51
            Items[51].ChildItemQuantities.Add(Items[24], 1);
            Items[51].ChildItemQuantities.Add(Items[27], 1);
            Items[51].ChildItemQuantities.Add(Items[16], 1);
            Items[51].ChildItemQuantities.Add(Items[17], 1);
            Items[51].ChildItemQuantities.Add(Items[50], 1);

            // 52 - 54: Procurement parts

            // 54
            Items[54].ChildItemQuantities.Add(Items[24], 2);
            Items[54].ChildItemQuantities.Add(Items[25], 2);
            Items[54].ChildItemQuantities.Add(Items[8], 1);
            Items[54].ChildItemQuantities.Add(Items[14], 1);
            Items[54].ChildItemQuantities.Add(Items[19], 1);

            // 55
            Items[55].ChildItemQuantities.Add(Items[24], 2);
            Items[55].ChildItemQuantities.Add(Items[25], 2);
            Items[55].ChildItemQuantities.Add(Items[5], 1);
            Items[55].ChildItemQuantities.Add(Items[11], 1);
            Items[55].ChildItemQuantities.Add(Items[54], 1);

            // 56
            Items[56].ChildItemQuantities.Add(Items[24], 1);
            Items[56].ChildItemQuantities.Add(Items[27], 1);
            Items[56].ChildItemQuantities.Add(Items[16], 1);
            Items[56].ChildItemQuantities.Add(Items[17], 1);
            Items[56].ChildItemQuantities.Add(Items[55], 1);

            // Create mock workplaces
            AddNewWorkplace(new Workplace { Id = 1 });
            AddNewWorkplace(new Workplace { Id = 2 });
            AddNewWorkplace(new Workplace { Id = 3 });
            AddNewWorkplace(new Workplace { Id = 4 });
            // Workplace 5 does not exist
            AddNewWorkplace(new Workplace { Id = 6 });
            AddNewWorkplace(new Workplace { Id = 7 });
            AddNewWorkplace(new Workplace { Id = 8 });
            AddNewWorkplace(new Workplace { Id = 9 });
            AddNewWorkplace(new Workplace { Id = 10 });
            AddNewWorkplace(new Workplace { Id = 11 });
            AddNewWorkplace(new Workplace { Id = 12 });
            AddNewWorkplace(new Workplace { Id = 13 });
            AddNewWorkplace(new Workplace { Id = 14 });
            AddNewWorkplace(new Workplace { Id = 15 });

            // Add mock jobs


            // Workplace 1
            AddNewItemJob(new ItemJob { Id = 1, Item = Items[29] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 6, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 2, Item = Items[49] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 6, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 3, Item = Items[54] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 6, SetupTime = 20.0 });

            // Workplace 2
            AddNewItemJob(new ItemJob { Id = 4, Item = Items[30] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 5, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 5, Item = Items[50] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 5, SetupTime = 30.0 });

            AddNewItemJob(new ItemJob { Id = 6, Item = Items[55] as ProducedItem, Workplace = Workplaces[2], ProductionTimePerPiece = 5, SetupTime = 30.0 });
            

            // Workplace 3
            AddNewItemJob(new ItemJob { Id = 7, Item = Items[31] as ProducedItem, Workplace = Workplaces[3], ProductionTimePerPiece = 6, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 8, Item = Items[51] as ProducedItem, Workplace = Workplaces[3], ProductionTimePerPiece = 5, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 9, Item = Items[56] as ProducedItem, Workplace = Workplaces[3], ProductionTimePerPiece = 6, SetupTime = 20.0 });


            // Workplace 4
            AddNewItemJob(new ItemJob { Id = 10, Item = Items[1] as ProducedItem, Workplace = Workplaces[4], ProductionTimePerPiece = 6, SetupTime = 30.0 });
            AddNewItemJob(new ItemJob { Id = 11, Item = Items[2] as ProducedItem, Workplace = Workplaces[4] });
            AddNewItemJob(new ItemJob { Id = 12, Item = Items[3] as ProducedItem, Workplace = Workplaces[4] });

            // There is no workplace 5 

            // Workplace 6
            AddNewItemJob(new ItemJob { Id = 13, Item = Items[16] as ProducedItem, Workplace = Workplaces[6], ProductionTimePerPiece = 2, SetupTime = 15.0 });

            AddNewItemJob(new ItemJob { Id = 14, Item = Items[18] as ProducedItem, Workplace = Workplaces[6], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 15, Item = Items[19] as ProducedItem, Workplace = Workplaces[6], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 16, Item = Items[20] as ProducedItem, Workplace = Workplaces[6], ProductionTimePerPiece = 3, SetupTime = 15.0 });

            //Workplace 7
            AddNewItemJob(new ItemJob { Id = 17, Item = Items[10] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 18, Item = Items[11] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 19, Item = Items[12] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 20, Item = Items[13] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 21, Item = Items[14] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 22, Item = Items[15] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 23, Item = Items[18] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 24, Item = Items[19] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 25, Item = Items[20] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 20.0 });

            AddNewItemJob(new ItemJob { Id = 26, Item = Items[26] as ProducedItem, Workplace = Workplaces[7], ProductionTimePerPiece = 2, SetupTime = 30.0 });

            // Workplace 8
            AddNewItemJob(new ItemJob { Id = 28, Item = Items[10] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 1, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 29, Item = Items[11] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 2, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 30, Item = Items[12] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 2, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 31, Item = Items[13] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 1, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 32, Item = Items[14] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 2, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 33, Item = Items[15] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 2, SetupTime = 15.0 });

            AddNewItemJob(new ItemJob { Id = 34, Item = Items[18] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 3, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 35, Item = Items[19] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 3, SetupTime = 25.0 });
            AddNewItemJob(new ItemJob { Id = 36, Item = Items[20] as ProducedItem, Workplace = Workplaces[8], ProductionTimePerPiece = 3, SetupTime = 20.0 });


            // Workplace 9
            AddNewItemJob(new ItemJob { Id = 37, Item = Items[10] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 38, Item = Items[11] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 39, Item = Items[12] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 40, Item = Items[13] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 41, Item = Items[14] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 42, Item = Items[15] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 3, SetupTime = 15.0 });

            AddNewItemJob(new ItemJob { Id = 43, Item = Items[18] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 2, SetupTime = 15.0 });
            AddNewItemJob(new ItemJob { Id = 44, Item = Items[19] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 2, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 45, Item = Items[20] as ProducedItem, Workplace = Workplaces[9], ProductionTimePerPiece = 2, SetupTime = 15.0 });


            // Workplace 10
            AddNewItemJob(new ItemJob { Id = 46, Item = Items[4] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 47, Item = Items[5] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 48, Item = Items[6] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 49, Item = Items[7] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 50, Item = Items[8] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 51, Item = Items[9] as ProducedItem, Workplace = Workplaces[10], ProductionTimePerPiece = 4, SetupTime = 20.0 });

            //Workplace 11
            AddNewItemJob(new ItemJob { Id = 52, Item = Items[4] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 10.0 });
            AddNewItemJob(new ItemJob { Id = 53, Item = Items[5] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 10.0 });
            AddNewItemJob(new ItemJob { Id = 54, Item = Items[6] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 20.0 });
            AddNewItemJob(new ItemJob { Id = 55, Item = Items[7] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 10.0 });
            AddNewItemJob(new ItemJob { Id = 56, Item = Items[8] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 10.0 });
            AddNewItemJob(new ItemJob { Id = 57, Item = Items[9] as ProducedItem, Workplace = Workplaces[11], ProductionTimePerPiece = 3, SetupTime = 20.0 });

            // Workplace 12
            AddNewItemJob(new ItemJob { Id = 58, Item = Items[10] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 59, Item = Items[11] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 60, Item = Items[12] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 61, Item = Items[13] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 62, Item = Items[14] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 63, Item = Items[15] as ProducedItem, Workplace = Workplaces[12], ProductionTimePerPiece = 3, SetupTime = 0.0 });
            
            // Workplace 13
            AddNewItemJob(new ItemJob { Id = 64, Item = Items[10] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 65, Item = Items[11] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 66, Item = Items[12] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 67, Item = Items[13] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 68, Item = Items[14] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });
            AddNewItemJob(new ItemJob { Id = 69, Item = Items[15] as ProducedItem, Workplace = Workplaces[13], ProductionTimePerPiece = 2, SetupTime = 0.0 });

            // Workplace 14
            AddNewItemJob(new ItemJob { Id = 70, Item = Items[16] as ProducedItem, Workplace = Workplaces[14], ProductionTimePerPiece = 3, SetupTime = 0.0 });

            // Workplace 15
            AddNewItemJob(new ItemJob { Id = 71, Item = Items[17] as ProducedItem, Workplace = Workplaces[15], ProductionTimePerPiece = 3, SetupTime = 15.0 });

            AddNewItemJob(new ItemJob { Id = 72, Item = Items[26] as ProducedItem, Workplace = Workplaces[15], ProductionTimePerPiece = 3, SetupTime = 15.0 });
        }

        /// <summary>
        /// Adds a new item
        /// </summary>
        /// <param name="item"></param>
        public void AddNewItem(Item item) {
            Items.Add(item.Id, item);
        }

        /// <summary>
        /// Adds a new workplace
        /// </summary>
        /// <param name="workplace"></param>
        public void AddNewWorkplace(Workplace workplace)
        {
            Workplaces.Add(workplace.Id, workplace);
        }

        /// <summary>
        /// Adds a new item job
        /// </summary>
        /// <param name="job"></param>
        public void AddNewItemJob(ItemJob job)
        {
            if (job.Workplace != null) {
                job.Workplace.Jobs.Add(job);
            }

            ItemJobs.Add(job.Id, job);
        }
    }
}
