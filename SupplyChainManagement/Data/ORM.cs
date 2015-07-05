using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SQLite;

using SupplyChainManagement.Models;
using SupplyChainManagement.Util;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Data
{
    public class ORM
    {
        private Dictionary<int, Item> _ItemCache = new Dictionary<int, Item>();

        public Dictionary<int, Workplace> _WorkplaceCache = new Dictionary<int, Workplace>();

        public Dictionary<int, ItemJob> _ItemJobCache = new Dictionary<int, ItemJob>();

        public ORM()
        {

            // Check whether directories and files do exist
            if (!Directory.Exists(Constants.MAIN_DIR))
            {
                Directory.CreateDirectory(Constants.MAIN_DIR);
            }

            if (!Directory.Exists(Constants.DATA_DIR))
            {
                Directory.CreateDirectory(Constants.DATA_DIR);
            }

            if (!File.Exists(Constants.DATABASE_FILE))
            {
                SQLiteConnection.CreateFile(Constants.DATABASE_FILE);

                using (var conn = new SQLiteConnection(Constants.CONNECTION_URI)) {
                    conn.Open();

                    CreateSchema();
                    CreateInitialData();
                }
            }
        }

        public void Purge()
        {

            if (File.Exists(Constants.DATABASE_FILE))
            {
                File.Delete(Constants.DATABASE_FILE);
            }

            SQLiteConnection.CreateFile(Constants.DATABASE_FILE);

            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI)) {
                conn.Open();

                CreateSchema();
                CreateInitialData();
            }
        }

        public void CreateSchema()
        {

            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            {
                conn.Open();
                // Create schema
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText("..\\..\\..\\SupplyChainManagement\\Sql\\schema.sql");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateInitialData()
        {
            
            // Create start data

            CreateItem(new FinishedProduct { Id = 1, Description = "Children's Bicycle", Value = 156.13, Stock = 100 });
            CreateItem(new FinishedProduct { Id = 2, Description = "Ladies Bicycle", Value = 163.33, Stock = 100 });
            CreateItem(new FinishedProduct { Id = 3, Description = "Men's Bicycle", Value = 165.08, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 4, Description = "Rear wheel group", Value = 40.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 5, Description = "Rear wheel group", Value = 39.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 6, Description = "Rear wheel group", Value = 40.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 7, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 8, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 9, Description = "Front wheel group", Value = 35.85, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 10, Description = "Mudguard rear", Value = 12.40, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 11, Description = "Mudguard rear", Value = 14.65, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 12, Description = "Mudguard rear", Value = 14.65, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 13, Description = "Mudguard front", Value = 12.40, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 14, Description = "Mudguard front", Value = 14.65, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 15, Description = "Mudguard front", Value = 14.65, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 16, Description = "Handle complete", Value = 7.02, Stock = 300 });
            CreateItem(new UnfinishedProduct { Id = 17, Description = "Saddle complete", Value = 1.16, Stock = 300 });
            CreateItem(new UnfinishedProduct { Id = 18, Description = "Frame", Value = 13.15, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 19, Description = "Frame", Value = 14.35, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 20, Description = "Frame", Value = 15.55, Stock = 100 });
            CreateItem(new ProcuredItem { Id = 21, Description = "Chain", Value = 5.0, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.8, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new ProcuredItem { Id = 22, Description = "Chain", Value = 6.5, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new ProcuredItem { Id = 23, Description = "Chain", Value = 6.5, Stock = 300, OrderCosts = 50.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new ProcuredItem { Id = 24, Description = "Nut 3/8 inch", Value = 0.06, Stock = 6100, OrderCosts = 100.0, ProcureLeadTime = 3.2, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 25, Description = "Washer 3/8 inch", Value = 0.06, Stock = 3600, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new UnfinishedProduct { Id = 26, Description = "Pedal complete", Value = 10.5, Stock = 300 });
            CreateItem(new ProcuredItem { Id = 27, Description = "Screw 3/8 inch", Value = 0.1, Stock = 1800, OrderCosts = 75.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new ProcuredItem { Id = 28, Description = "Tube 3/4 inch", Value = 1.2, Stock = 4500, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new UnfinishedProduct { Id = 29, Description = "Front wheel compl.", Value = 69.29, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 30, Description = "Frame and wheels", Value = 127.53, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 31, Description = "Bicycle w/o wheels", Value = 144.42, Stock = 100 });
            CreateItem(new ProcuredItem { Id = 32, Description = "Paint", Value = 0.75, Stock = 2700, OrderCosts = 50.0, ProcureLeadTime = 2.1, ProcureLeadTimeDeviation = 0.5 });
            CreateItem(new ProcuredItem { Id = 33, Description = "Rim compl.", Value = 22.0, Stock = 900, OrderCosts = 75.0, ProcureLeadTime = 1.9, ProcureLeadTimeDeviation = 0.5 });
            CreateItem(new ProcuredItem { Id = 34, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 35, Description = "Taper sleeve", Value = 1.0, Stock = 3600, OrderCosts = 75.0, ProcureLeadTime = 2.2, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new ProcuredItem { Id = 36, Description = "Free wheel", Value = 8.0, Stock = 900, OrderCosts = 100.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.1 });
            CreateItem(new ProcuredItem { Id = 37, Description = "Fork", Value = 1.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.5, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 38, Description = "Axle", Value = 1.5, Stock = 300, OrderCosts = 75.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new ProcuredItem { Id = 39, Description = "Sheet", Value = 1.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.5, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 40, Description = "Handle Bar", Value = 2.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new ProcuredItem { Id = 41, Description = "Nut 3/4 inch", Value = 0.06, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new ProcuredItem { Id = 42, Description = "Handle Grip", Value = 0.1, Stock = 1800, OrderCosts = 50.0, ProcureLeadTime = 1.2, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 43, Description = "Saddle", Value = 5.0, Stock = 1900, OrderCosts = 75.0, ProcureLeadTime = 2.0, ProcureLeadTimeDeviation = 0.5 });
            CreateItem(new ProcuredItem { Id = 44, Description = "Bar 1/2 inch", Value = 0.5, Stock = 2700, OrderCosts = 50.0, ProcureLeadTime = 1.0, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new ProcuredItem { Id = 45, Description = "Nut 1/4 inch", Value = 0.06, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 46, Description = "Screw 1/4 inch", Value = 0.1, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 0.9, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 47, Description = "Sprocket", Value = 3.5, Stock = 900, OrderCosts = 50.0, ProcureLeadTime = 1.41, ProcureLeadTimeDeviation = 0.1 });
            CreateItem(new ProcuredItem { Id = 48, Description = "Pedal", Value = 1.5, Stock = 1800, OrderCosts = 75.0, ProcureLeadTime = 1.0, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new UnfinishedProduct { Id = 49, Description = "Front wheel complete", Value = 64.64, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 50, Description = "Frame and wheels", Value = 120.63, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 51, Description = "Bicycle w/o pedals", Value = 137.47, Stock = 100 });
            CreateItem(new ProcuredItem { Id = 52, Description = "Rim compl.", Value = 22.0, Stock = 600, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.4 });
            CreateItem(new ProcuredItem { Id = 53, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.2 });
            CreateItem(new UnfinishedProduct { Id = 54, Description = "Front wheel compl.", Value = 68.09, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 55, Description = "Frame and wheels", Value = 125.33, Stock = 100 });
            CreateItem(new UnfinishedProduct { Id = 56, Description = "Bicycle w/o pedals", Value = 142.67, Stock = 100 });
            CreateItem(new ProcuredItem { Id = 57, Description = "Rim compl.", Value = 22.0, Stock = 600, OrderCosts = 50.0, ProcureLeadTime = 1.7, ProcureLeadTimeDeviation = 0.3 });
            CreateItem(new ProcuredItem { Id = 58, Description = "Spoke", Value = 0.1, Stock = 22000, OrderCosts = 50.0, ProcureLeadTime = 1.6, ProcureLeadTimeDeviation = 0.5 });
            CreateItem(new ProcuredItem { Id = 59, Description = "Welding wires", Value = 0.15, Stock = 1800, OrderCosts = 50.0, ProcureLeadTime = 0.7, ProcureLeadTimeDeviation = 0.2 });

            // 1
            AddChildToProduct(GetItemById(1) as Product, GetItemById(21), 1);
            AddChildToProduct(GetItemById(1) as Product, GetItemById(24), 1);
            AddChildToProduct(GetItemById(1) as Product ,GetItemById(27), 1);
            AddChildToProduct(GetItemById(1) as Product, GetItemById(26), 1);
            AddChildToProduct(GetItemById(1) as Product, GetItemById(51), 1);

            // 2
            AddChildToProduct(GetItemById(2) as Product,GetItemById(22), 1);
            AddChildToProduct(GetItemById(2) as Product,GetItemById(24), 1);
            AddChildToProduct(GetItemById(2) as Product,GetItemById(27), 1);
            AddChildToProduct(GetItemById(2) as Product,GetItemById(26), 1);
            AddChildToProduct(GetItemById(2) as Product,GetItemById(56), 1);

            // 3
            AddChildToProduct(GetItemById(3) as Product,GetItemById(23), 1);
            AddChildToProduct(GetItemById(3) as Product,GetItemById(24), 1);
            AddChildToProduct(GetItemById(3) as Product,GetItemById(27), 1);
            AddChildToProduct(GetItemById(3) as Product,GetItemById(26), 1);
            AddChildToProduct(GetItemById(3) as Product,GetItemById(31), 1);

            // 4
            AddChildToProduct(GetItemById(4) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(4) as Product,GetItemById(36), 1);
            AddChildToProduct(GetItemById(4) as Product,GetItemById(52), 1);
            AddChildToProduct(GetItemById(4) as Product,GetItemById(53), 36);

            // 5
            AddChildToProduct(GetItemById(5) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(5) as Product,GetItemById(36), 1);
            AddChildToProduct(GetItemById(5) as Product,GetItemById(57), 1);
            AddChildToProduct(GetItemById(5) as Product,GetItemById(58), 36);

            // 6
            AddChildToProduct(GetItemById(6) as Product,GetItemById(33), 1);
            AddChildToProduct(GetItemById(6) as Product,GetItemById(34), 36);
            AddChildToProduct(GetItemById(6) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(6) as Product,GetItemById(36), 1);

            // 7
            AddChildToProduct(GetItemById(7) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(7) as Product,GetItemById(37), 1);
            AddChildToProduct(GetItemById(7) as Product,GetItemById(38), 1);
            AddChildToProduct(GetItemById(7) as Product,GetItemById(52), 1);
            AddChildToProduct(GetItemById(7) as Product,GetItemById(53), 36);

            // 8
            AddChildToProduct(GetItemById(8) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(8) as Product,GetItemById(37), 1);
            AddChildToProduct(GetItemById(8) as Product,GetItemById(38), 1);
            AddChildToProduct(GetItemById(8) as Product,GetItemById(57), 1);
            AddChildToProduct(GetItemById(8) as Product,GetItemById(58), 36);

            // 9
            AddChildToProduct(GetItemById(9) as Product,GetItemById(33), 1);
            AddChildToProduct(GetItemById(9) as Product,GetItemById(34), 36);
            AddChildToProduct(GetItemById(9) as Product,GetItemById(35), 2);
            AddChildToProduct(GetItemById(9) as Product,GetItemById(37), 1);
            AddChildToProduct(GetItemById(9) as Product,GetItemById(38), 1);

            // 10
            AddChildToProduct(GetItemById(10) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(10) as Product,GetItemById(39), 1);

            // 11
            AddChildToProduct(GetItemById(11) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(11) as Product,GetItemById(39), 1);

            // 12
            AddChildToProduct(GetItemById(12) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(12) as Product,GetItemById(39), 1);

            // 13
            AddChildToProduct(GetItemById(13) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(13) as Product,GetItemById(39), 1);

            // 14
            AddChildToProduct(GetItemById(14) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(14) as Product,GetItemById(39), 1);

            // 15
            AddChildToProduct(GetItemById(15) as Product,GetItemById(32), 1);
            AddChildToProduct(GetItemById(15) as Product,GetItemById(39), 1);

            // 16
            AddChildToProduct(GetItemById(16) as Product,GetItemById(24), 1);
            AddChildToProduct(GetItemById(16) as Product,GetItemById(28), 1);
            AddChildToProduct(GetItemById(16) as Product,GetItemById(40), 1);
            AddChildToProduct(GetItemById(16) as Product,GetItemById(41), 1);
            AddChildToProduct(GetItemById(16) as Product,GetItemById(42), 2);

            // 17
            AddChildToProduct(GetItemById(17) as Product, GetItemById(43), 1);
            AddChildToProduct(GetItemById(17) as Product, GetItemById(44), 1);
            AddChildToProduct(GetItemById(17) as Product, GetItemById(45), 1);
            AddChildToProduct(GetItemById(17) as Product, GetItemById(46), 1);

            // 18
            AddChildToProduct(GetItemById(18) as Product, GetItemById(28), 3);
            AddChildToProduct(GetItemById(18) as Product, GetItemById(32), 1);
            AddChildToProduct(GetItemById(18) as Product, GetItemById(59), 2);

            // 19
            AddChildToProduct(GetItemById(19) as Product, GetItemById(28), 4);
            AddChildToProduct(GetItemById(19) as Product, GetItemById(32), 1);
            AddChildToProduct(GetItemById(19) as Product, GetItemById(59), 2);

            // 20
            AddChildToProduct(GetItemById(20) as Product, GetItemById(28), 5);
            AddChildToProduct(GetItemById(20) as Product, GetItemById(32), 1);
            AddChildToProduct(GetItemById(20) as Product, GetItemById(59), 2);

            // 21-25: Procurement parts

            // 26
            AddChildToProduct(GetItemById(26) as Product, GetItemById(44), 2);
            AddChildToProduct(GetItemById(26) as Product, GetItemById(47), 1);
            AddChildToProduct(GetItemById(26) as Product, GetItemById(48), 2);

            // 27-28: Procurement parts

            // 29
            AddChildToProduct(GetItemById(29) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(29) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(29) as Product, GetItemById(9), 1);
            AddChildToProduct(GetItemById(29) as Product, GetItemById(15), 1);
            AddChildToProduct(GetItemById(29) as Product, GetItemById(20), 1);

            // 30
            AddChildToProduct(GetItemById(30) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(30) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(30) as Product, GetItemById(6), 1);
            AddChildToProduct(GetItemById(30) as Product, GetItemById(12), 1);
            AddChildToProduct(GetItemById(30) as Product, GetItemById(29), 1);

            // 31
            AddChildToProduct(GetItemById(31) as Product, GetItemById(24), 1);
            AddChildToProduct(GetItemById(31) as Product, GetItemById(27), 1);
            AddChildToProduct(GetItemById(31) as Product, GetItemById(16), 1);
            AddChildToProduct(GetItemById(31) as Product, GetItemById(17), 1);
            AddChildToProduct(GetItemById(31) as Product, GetItemById(30), 1);

            // 32 - 48: Procurement parts

            // 49
            AddChildToProduct(GetItemById(49) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(49) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(49) as Product, GetItemById(7), 1);
            AddChildToProduct(GetItemById(49) as Product, GetItemById(13), 1);
            AddChildToProduct(GetItemById(49) as Product, GetItemById(18), 1);

            // 50
            AddChildToProduct(GetItemById(50) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(50) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(50) as Product, GetItemById(4), 1);
            AddChildToProduct(GetItemById(50) as Product, GetItemById(10), 1);
            AddChildToProduct(GetItemById(50) as Product, GetItemById(49), 1);

            // 51
            AddChildToProduct(GetItemById(51) as Product, GetItemById(24), 1);
            AddChildToProduct(GetItemById(51) as Product, GetItemById(27), 1);
            AddChildToProduct(GetItemById(51) as Product, GetItemById(16), 1);
            AddChildToProduct(GetItemById(51) as Product, GetItemById(17), 1);
            AddChildToProduct(GetItemById(51) as Product, GetItemById(50), 1);

            // 52 - 54: Procurement parts

            // 54
            AddChildToProduct(GetItemById(54) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(54) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(54) as Product, GetItemById(8), 1);
            AddChildToProduct(GetItemById(54) as Product, GetItemById(14), 1);
            AddChildToProduct(GetItemById(54) as Product, GetItemById(19), 1);

            // 55
            AddChildToProduct(GetItemById(55) as Product, GetItemById(24), 2);
            AddChildToProduct(GetItemById(55) as Product, GetItemById(25), 2);
            AddChildToProduct(GetItemById(55) as Product, GetItemById(5), 1);
            AddChildToProduct(GetItemById(55) as Product, GetItemById(11), 1);
            AddChildToProduct(GetItemById(55) as Product, GetItemById(54), 1);

            // 56
            AddChildToProduct(GetItemById(56) as Product, GetItemById(24), 1);
            AddChildToProduct(GetItemById(56) as Product, GetItemById(27), 1);
            AddChildToProduct(GetItemById(56) as Product, GetItemById(16), 1);
            AddChildToProduct(GetItemById(56) as Product, GetItemById(17), 1);
            AddChildToProduct(GetItemById(56) as Product, GetItemById(55), 1);


            // Add "where used" references

            // Create mock workplaces
            CreateWorkplace(new Workplace { Id = 1 });
            CreateWorkplace(new Workplace { Id = 2 });
            CreateWorkplace(new Workplace { Id = 3 });
            CreateWorkplace(new Workplace { Id = 4 });
            // Workplace 5 does not exist
            CreateWorkplace(new Workplace { Id = 6 });
            CreateWorkplace(new Workplace { Id = 7 });
            CreateWorkplace(new Workplace { Id = 8 });
            CreateWorkplace(new Workplace { Id = 9 });
            CreateWorkplace(new Workplace { Id = 10 });
            CreateWorkplace(new Workplace { Id = 11 });
            CreateWorkplace(new Workplace { Id = 12 });
            CreateWorkplace(new Workplace { Id = 13 });
            CreateWorkplace(new Workplace { Id = 14 });
            CreateWorkplace(new Workplace { Id = 15 });

            // Add mock jobs


            // Workplace 1
            CreateItemJob(new ItemJob { Id = 1, Product = (Product)GetItemById(29), Workplace = GetWorkplaceById(1), ProductionTimePerPiece = 6, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 2, Product = (Product)GetItemById(49), Workplace = GetWorkplaceById(1), ProductionTimePerPiece = 6, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 3, Product = (Product)GetItemById(54), Workplace = GetWorkplaceById(1), ProductionTimePerPiece = 6, SetupTime = 20.0 });

            // Workplace 2
            CreateItemJob(new ItemJob { Id = 4, Product = (Product)GetItemById(30), Workplace = GetWorkplaceById(2), ProductionTimePerPiece = 5, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 5, Product = (Product)GetItemById(50), Workplace = GetWorkplaceById(2), ProductionTimePerPiece = 5, SetupTime = 30.0 });

            CreateItemJob(new ItemJob { Id = 6, Product = (Product)GetItemById(55), Workplace = GetWorkplaceById(2), ProductionTimePerPiece = 5, SetupTime = 30.0 });


            // Workplace 3
            CreateItemJob(new ItemJob { Id = 7, Product = (Product)GetItemById(31), Workplace = GetWorkplaceById(3), ProductionTimePerPiece = 6, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 8, Product = (Product)GetItemById(51), Workplace = GetWorkplaceById(3), ProductionTimePerPiece = 5, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 9, Product = (Product)GetItemById(56), Workplace = GetWorkplaceById(3), ProductionTimePerPiece = 6, SetupTime = 20.0 });


            // Workplace 4
            CreateItemJob(new ItemJob { Id = 10, Product = (Product)GetItemById(1), Workplace = GetWorkplaceById(4), ProductionTimePerPiece = 6, SetupTime = 30.0 });
            CreateItemJob(new ItemJob { Id = 11, Product = (Product)GetItemById(2), Workplace = GetWorkplaceById(4), ProductionTimePerPiece = 7, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 12, Product = (Product)GetItemById(3), Workplace = GetWorkplaceById(4), ProductionTimePerPiece = 7, SetupTime = 30.0 });

            // There is no workplace 5 

            // Workplace 6
            CreateItemJob(new ItemJob { Id = 13, Product = (Product)GetItemById(16), Workplace = GetWorkplaceById(6), ProductionTimePerPiece = 2, SetupTime = 15.0 });

            CreateItemJob(new ItemJob { Id = 14, Product = (Product)GetItemById(18), Workplace = GetWorkplaceById(6), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 15, Product = (Product)GetItemById(19), Workplace = GetWorkplaceById(6), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 16, Product = (Product)GetItemById(20), Workplace = GetWorkplaceById(6), ProductionTimePerPiece = 3, SetupTime = 15.0 });

            //Workplace 7
            CreateItemJob(new ItemJob { Id = 17, Product = (Product)GetItemById(10), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 18, Product = (Product)GetItemById(11), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 19, Product = (Product)GetItemById(12), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 20, Product = (Product)GetItemById(13), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 21, Product = (Product)GetItemById(14), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 22, Product = (Product)GetItemById(15), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 23, Product = (Product)GetItemById(18), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 24, Product = (Product)GetItemById(19), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 25, Product = (Product)GetItemById(20), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 20.0 });

            CreateItemJob(new ItemJob { Id = 26, Product = (Product)GetItemById(26), Workplace = GetWorkplaceById(7), ProductionTimePerPiece = 2, SetupTime = 30.0 });

            // Workplace 8
            CreateItemJob(new ItemJob { Id = 28, Product = (Product)GetItemById(10), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 1, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 29, Product = (Product)GetItemById(11), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 2, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 30, Product = (Product)GetItemById(12), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 2, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 31, Product = (Product)GetItemById(13), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 1, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 32, Product = (Product)GetItemById(14), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 2, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 33, Product = (Product)GetItemById(15), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 2, SetupTime = 15.0 });

            CreateItemJob(new ItemJob { Id = 34, Product = (Product)GetItemById(18), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 3, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 35, Product = (Product)GetItemById(19), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 3, SetupTime = 25.0 });
            CreateItemJob(new ItemJob { Id = 36, Product = (Product)GetItemById(20), Workplace = GetWorkplaceById(8), ProductionTimePerPiece = 3, SetupTime = 20.0 });


            // Workplace 9
            CreateItemJob(new ItemJob { Id = 37, Product = (Product)GetItemById(10), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 38, Product = (Product)GetItemById(11), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 39, Product = (Product)GetItemById(12), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 40, Product = (Product)GetItemById(13), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 41, Product = (Product)GetItemById(14), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 42, Product = (Product)GetItemById(15), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 3, SetupTime = 15.0 });

            CreateItemJob(new ItemJob { Id = 43, Product = (Product)GetItemById(18), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 2, SetupTime = 15.0 });
            CreateItemJob(new ItemJob { Id = 44, Product = (Product)GetItemById(19), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 2, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 45, Product = (Product)GetItemById(20), Workplace = GetWorkplaceById(9), ProductionTimePerPiece = 2, SetupTime = 15.0 });


            // Workplace 10
            CreateItemJob(new ItemJob { Id = 46, Product = (Product)GetItemById(4), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 47, Product = (Product)GetItemById(5), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 48, Product = (Product)GetItemById(6), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 49, Product = (Product)GetItemById(7), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 50, Product = (Product)GetItemById(8), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 51, Product = (Product)GetItemById(9), Workplace = GetWorkplaceById(10), ProductionTimePerPiece = 4, SetupTime = 20.0 });

            //Workplace 11
            CreateItemJob(new ItemJob { Id = 52, Product = (Product)GetItemById(4), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 10.0 });
            CreateItemJob(new ItemJob { Id = 53, Product = (Product)GetItemById(5), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 10.0 });
            CreateItemJob(new ItemJob { Id = 54, Product = (Product)GetItemById(6), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 20.0 });
            CreateItemJob(new ItemJob { Id = 55, Product = (Product)GetItemById(7), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 10.0 });
            CreateItemJob(new ItemJob { Id = 56, Product = (Product)GetItemById(8), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 10.0 });
            CreateItemJob(new ItemJob { Id = 57, Product = (Product)GetItemById(9), Workplace = GetWorkplaceById(11), ProductionTimePerPiece = 3, SetupTime = 20.0 });

            // Workplace 12
            CreateItemJob(new ItemJob { Id = 58, Product = (Product)GetItemById(10), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 59, Product = (Product)GetItemById(11), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 60, Product = (Product)GetItemById(12), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 61, Product = (Product)GetItemById(13), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 62, Product = (Product)GetItemById(14), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 63, Product = (Product)GetItemById(15), Workplace = GetWorkplaceById(12), ProductionTimePerPiece = 3, SetupTime = 0.0 });

            // Workplace 13
            CreateItemJob(new ItemJob { Id = 64, Product = (Product)GetItemById(10), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 65, Product = (Product)GetItemById(11), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 66, Product = (Product)GetItemById(12), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 67, Product = (Product)GetItemById(13), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 68, Product = (Product)GetItemById(14), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });
            CreateItemJob(new ItemJob { Id = 69, Product = (Product)GetItemById(15), Workplace = GetWorkplaceById(13), ProductionTimePerPiece = 2, SetupTime = 0.0 });

            // Workplace 14
            CreateItemJob(new ItemJob { Id = 70, Product = (Product)GetItemById(16), Workplace = GetWorkplaceById(14), ProductionTimePerPiece = 3, SetupTime = 0.0 });

            // Workplace 15
            CreateItemJob(new ItemJob { Id = 71, Product = (Product)GetItemById(17), Workplace = GetWorkplaceById(15), ProductionTimePerPiece = 3, SetupTime = 15.0 });

            CreateItemJob(new ItemJob { Id = 72, Product = (Product)GetItemById(26), Workplace = GetWorkplaceById(15), ProductionTimePerPiece = 3, SetupTime = 15.0 });

            // Create Item Job references

            AppendNextItemJob(26, 7, 15);
            AppendNextItemJob(16, 6, 14);

            // P1
            AppendNextItemJob(4, 10, 11);

            AppendNextItemJob(10, 7, 9);
            AppendNextItemJob(10, 8, 7);
            AppendNextItemJob(10, 12, 8);
            AppendNextItemJob(10, 13, 12);

            AppendNextItemJob(7, 10, 11);

            AppendNextItemJob(18, 7, 9);
            AppendNextItemJob(18, 8, 7);
            AppendNextItemJob(18, 6, 8);

            AppendNextItemJob(13, 7, 9);
            AppendNextItemJob(13, 8, 7);
            AppendNextItemJob(13, 12, 8);
            AppendNextItemJob(13, 13, 12);

            // P2
            AppendNextItemJob(5, 10, 11);

            AppendNextItemJob(11, 7, 9);
            AppendNextItemJob(11, 8, 7);
            AppendNextItemJob(11, 12, 8);
            AppendNextItemJob(11, 13, 12);

            AppendNextItemJob(8, 10, 11);

            AppendNextItemJob(19, 7, 9);
            AppendNextItemJob(19, 8, 7);
            AppendNextItemJob(19, 6, 8);

            AppendNextItemJob(14, 7, 9);
            AppendNextItemJob(14, 8, 7);
            AppendNextItemJob(14, 12, 8);
            AppendNextItemJob(14, 13, 12);

            // P3
            AppendNextItemJob(6, 10, 11);

            AppendNextItemJob(12, 7, 9);
            AppendNextItemJob(12, 8, 7);
            AppendNextItemJob(12, 12, 8);
            AppendNextItemJob(12, 13, 12);

            AppendNextItemJob(9, 10, 11);

            AppendNextItemJob(20, 7, 9);
            AppendNextItemJob(20, 8, 7);
            AppendNextItemJob(20, 6, 8);

            AppendNextItemJob(15, 7, 9);
            AppendNextItemJob(15, 8, 7);
            AppendNextItemJob(15, 12, 8);
            AppendNextItemJob(15, 13, 12);

        }



        public string _GenerateUpdateFromDict(string table, int recordId, Dictionary<string, object> dict)
        {

            List<string> keyValuePairs = new List<string>();

            foreach (var key in dict.Keys)
            {
                if (key == Values.Id)
                {
                    continue;
                }
                else if (dict[key] == null)
                {
                    keyValuePairs.Add(key + "=null");
                }
                else if (dict[key] is string)
                {
                    keyValuePairs.Add(key + "=\"" + dict[key] + "\"");
                }
                else
                {
                    var value = dict[key];
                    if (value == null)
                    {
                        keyValuePairs.Add(key + "=null");
                    }
                    else
                    {
                        keyValuePairs.Add(key + "=" + value.ToString());
                    }
                }

            }

            return "UPDATE " + table + " SET " + String.Join(", ", keyValuePairs) + " WHERE " + Values.Id + "=" + recordId + ";";
        }


        private string _GenerateInsertFromDict(string table, Dictionary<string, object> dict)
        {
            var values = new List<string>();
            foreach (var key in dict.Keys)
            {
                
                if (dict[key] == null)
                {
                    values.Add("null");
                }
                else if (dict[key] is string)
                {
                    values.Add("\"" + dict[key] + "\"");
                }
                else
                {
                    var value = dict[key];
                    if (value == null)
                    {
                        values.Add(null);
                    }
                    else
                    {
                        values.Add(value.ToString());
                    }
                }

            }
            return "INSERT INTO " + table + " (" + String.Join(", ", dict.Keys) + ") VALUES ("
                   + String.Join(", ", values) + ");";
        }

        public Item GetItemById(int id)
        {

            if (!_ItemCache.ContainsKey(id))
            {
                return null;
            }
            //    Item item = null;
            //    using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //    {
            //        conn.Open();
            //        using (var cmd = conn.CreateCommand())
            //        {
            //            cmd.CommandText = "select * from " + Values.Item + " where " + Values.Id + " = " + id;

            //            using (var reader = cmd.ExecuteReader())
            //            {

            //                if (!reader.Read())
            //                {

            //                    return null;
            //                }

            //                var type = (string)reader[Values.Type];

            //                if (type == Values.ProcuredItem)
            //                {
            //                    item = new ProcuredItem();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    (item as ProcuredItem).DiscountQuantity = (int)reader[Values.DiscountQuantity];
            //                    (item as ProcuredItem).OrderCosts = (double)reader[Values.OrderCosts];
            //                    (item as ProcuredItem).ProcureLeadTime = (double)reader[Values.ProcureLeadTime];
            //                    (item as ProcuredItem).ProcureLeadTimeDeviation = (double)reader[Values.ProcureLeadTimeDeviation];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else if (type == Values.UnfinishedProduct)
            //                {
            //                    item = new UnfinishedProduct();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else if (type == Values.FinishedProduct)
            //                {
            //                    item = new FinishedProduct();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else
            //                {
            //                    throw new Exception("Invalid item type");
            //                }
            //            }
            //        }


            //        if (item is Product) {
            //            using (var cmd = conn.CreateCommand())
            //            {
            //                cmd.CommandText = "select * from " + Values.ChildToProduct + " where " + Values.Product_Id + " = " + item.Id;

            //                using (var childsReader = cmd.ExecuteReader())
            //                {
            //                    while (childsReader.Read())
            //                    {
            //                        var childId = (int)childsReader[Values.Child_Id];
            //                        var quantity = (int)childsReader[Values.Quantity];
            //                        (item as Product).AddItem(GetItemById(childId), quantity);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return _ItemCache[id];
        }

        public Workplace GetWorkplaceById(int id)
        {

            if (!_WorkplaceCache.ContainsKey(id))
            {
                return null;
            }
            //    using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //    {
            //        conn.Open();
            //        using (var cmd = conn.CreateCommand())
            //        {

            //            cmd.CommandText = "select * from " + Values.Workplace + " where " + Values.Id + " = " + id;
            //            using (var reader = cmd.ExecuteReader())
            //            {

            //                if (!reader.Read())
            //                {
            //                    return null;
            //                }

            //                var workplace = new Workplace
            //                {
            //                    Id = (int)reader[Values.Id],
            //                    IdleMachineCosts = (double)reader[Values.IdleMachineCosts],
            //                    JobDescription = reader[Values.JobDescription] as string,
            //                    LaborCostsFirstShift = (double)reader[Values.LaborCostsFirstShift],
            //                    LaborCostsSecondShift = (double)reader[Values.LaborCostsSecondShift],
            //                    LaborCostsThirdShift = (double)reader[Values.LaborCostsThirdShift],
            //                    LaborCostsOvertime = (double)reader[Values.LaborCostsOvertime],
            //                    ProductiveMachineCosts = (double)reader[Values.ProductiveMachineCosts]
            //                };

            //                _WorkplaceCache.Add(workplace.Id, workplace);

            //            }
            //        }
            //    }

            //    using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //    {
            //        conn.Open();
            //        using (var cmd = conn.CreateCommand())
            //        {

            //            cmd.CommandText = "select * from " + Values.ItemJob + " where " + Values.Workplace_Id + " = " + id;
            //            using (var reader = cmd.ExecuteReader())
            //            {
            //                while (reader.NextResult()) {
            //                    _WorkplaceCache[id].Jobs.Add(GetItemJobById((int)reader[Values.Id]));
            //                }
            //            }
            //        }
            //    }
            //}
            return _WorkplaceCache[id];

            
        }


        public List<Workplace> GetAllWorkplaces()
        {
            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();

            //    using (var cmd = conn.CreateCommand())
            //    {

            //        cmd.CommandText = "select * from Item";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {

            //                var currentItemId = (int)reader[Values.Id];

            //                if (_ItemCache.ContainsKey(currentItemId))
            //                {
            //                    continue;
            //                }

            //                var workplace = new Workplace
            //                {
            //                    Id = (int)reader[Values.Id],
            //                    IdleMachineCosts = (double)reader[Values.IdleMachineCosts],
            //                    JobDescription = reader[Values.JobDescription] as string,
            //                    LaborCostsFirstShift = (double)reader[Values.LaborCostsFirstShift],
            //                    LaborCostsSecondShift = (double)reader[Values.LaborCostsSecondShift],
            //                    LaborCostsThirdShift = (double)reader[Values.LaborCostsThirdShift],
            //                    LaborCostsOvertime = (double)reader[Values.LaborCostsOvertime],
            //                    ProductiveMachineCosts = (double)reader[Values.ProductiveMachineCosts]
            //                };

            //                _WorkplaceCache.Add(workplace.Id, workplace);

            //            }
            //        }
            //    }
            //}

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();

            //    foreach (var workplace in _WorkplaceCache.Values)
            //    {
            //        using (var cmd = conn.CreateCommand())
            //        {

            //            cmd.CommandText = "select * from " + Values.ItemJob + " where " + Values.Workplace_Id + " = " + workplace.Id;
            //            using (var reader = cmd.ExecuteReader())
            //            {
            //                while (reader.NextResult())
            //                {
            //                    var itemJob = GetItemJobById((int)reader[Values.Id]);
            //                    if (!_WorkplaceCache[workplace.Id].Jobs.Contains(itemJob))
            //                    {
            //                        _WorkplaceCache[workplace.Id].Jobs.Add(itemJob);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            return new List<Workplace>(_WorkplaceCache.Values);
        }


        public List<ItemJob> GetAllItemJobs()
        {


            //var jobs = new List<ItemJob>();
            //var productIds = new List<int>();
            //var workplaceIds = new List<int>();
            //var nextJobIds = new List<int>();

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();

            //    using (var cmd = conn.CreateCommand())
            //    {

            //        cmd.CommandText = "select * from " + Values.ItemJob;
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {

            //                var currentItemJobId = (int)reader[Values.Id];

            //                if (_ItemJobCache.ContainsKey(currentItemJobId))
            //                {
            //                    continue;
            //                }

            //                var job = new ItemJob();
            //                job.Id = currentItemJobId;
            //                job.SetupTime = (double)reader[Values.SetupTime];
            //                job.ProductionTimePerPiece = (double)reader[Values.ProductionTimePerPiece];
            //                jobs.Add(job);

            //                var productId = (int)reader[Values.Product_Id];
            //                var workplaceId = (int)reader[Values.Workplace_Id];

            //                productIds.Add(productId);
            //                workplaceIds.Add(workplaceId);

            //                try
            //                {
            //                    nextJobIds.Add((int)reader[Values.NextItemJob_Id]);
            //                }
            //                catch (InvalidCastException)
            //                {
            //                    nextJobIds.Add(-1);
            //                }

            //            }
            //        }
            //    }
            //}

            //for (var i = 0; i < jobs.Count; i++) {
            //    var productId = productIds[i];
            //    var workplaceId = workplaceIds[i];
            //    var nextJobId = nextJobIds[i];

            //    jobs[i].Product = (Product) GetItemById(productId);
            //    jobs[i].Workplace = GetWorkplaceById(workplaceId);

            //    if (nextJobId < 0)
            //    {
            //        jobs[i].NextItemJob = null;
            //    }
            //    else
            //    {
            //        jobs[i].NextItemJob = GetItemJobById(nextJobId);
            //    }
            //}

            //foreach (ItemJob job in jobs) {
            //    if (!_ItemJobCache.ContainsKey(job.Id))
            //    {
            //        _ItemJobCache.Add(job.Id, job);
            //    }
            //    else
            //    {
            //        _ItemJobCache[job.Id].NextItemJob = job.NextItemJob;
            //    }
            //}

            return new List<ItemJob>(_ItemJobCache.Values);

        }

        public List<Item> GetAllItems()
        {

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();

            //    using (var cmd = conn.CreateCommand())
            //    {

            //        cmd.CommandText = "select * from " + Values.Item;
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read()) {
                            
            //                var currentItemId = (int) reader[Values.Id];

            //                if (_ItemCache.ContainsKey(currentItemId))
            //                {
            //                    continue;
            //                }

            //                var type = (string)reader[Values.Type];

            //                if (type == Values.ProcuredItem)
            //                {
            //                    var item = new ProcuredItem();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    item.DiscountQuantity = (int)reader[Values.DiscountQuantity];
            //                    item.OrderCosts = (double)reader[Values.OrderCosts];
            //                    item.ProcureLeadTime = (double)reader[Values.ProcureLeadTime];
            //                    item.ProcureLeadTimeDeviation = (double)reader[Values.ProcureLeadTimeDeviation];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else if (type == Values.UnfinishedProduct)
            //                {
            //                    var item = new UnfinishedProduct();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else if (type == Values.FinishedProduct)
            //                {
            //                    var item = new FinishedProduct();
            //                    item.Id = (int)reader[Values.Id];
            //                    item.Description = (string)reader[Values.Description];
            //                    item.Stock = (int)reader[Values.Stock];
            //                    item.Value = (double)reader[Values.Value];

            //                    _ItemCache.Add(item.Id, item);
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //        }
            //    }
            //}

            return new List<Item>(_ItemCache.Values);
        }


        public void AppendNextItemJob(int productId, int workplaceId, int nextWorkplaceId)
        {
            var product = (Product) GetItemById(productId);
            var workplace = GetWorkplaceById(workplaceId);
            var nextWorkplace = GetWorkplaceById(nextWorkplaceId);

            var itemJob = GetItemJobByWorkplaceAndProduct(
                    workplace,
                    product
                );

            product = (Product)GetItemById(productId);

            var nextItemJob = 
                GetItemJobByWorkplaceAndProduct(
                    nextWorkplace,
                    product
                );

            AppendNextItemJob(
                ref itemJob,
                nextItemJob
            );
        }

        public void AppendNextItemJob(ref ItemJob itemJob, ItemJob nextItemJob)
        {
            if (itemJob.Id == nextItemJob.Id)
            {
                throw new Exception("Item and next item must not be the same");
            }

            if (itemJob.Product.Id != nextItemJob.Product.Id)
            {
                throw new Exception("Item and next item must produce the same product");
            }

            //var itemJobFromDb = GetItemJobById(itemJob.Id);
            //var nextItemJobFromDb = GetItemJobById(nextItemJob.Id);

            //if (!_ItemJobCache.ContainsKey(itemJob.Id))
            //{
            //    throw new Exception("Item not found");
            //}
            //if (!_ItemJobCache.ContainsKey(nextItemJob.Id))
            //{
            //    throw new Exception("Next item not found");
            //}


            //var dict = new Dictionary<string, object>();
            //dict[Values.NextItemJob_Id] = nextItemJob.Id;

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = _GenerateUpdateFromDict(Values.ItemJob, itemJob.Id, dict);
            //        cmd.ExecuteNonQuery();

            //    }
            //}

            _ItemJobCache[itemJob.Id].NextItemJob = GetItemJobById(nextItemJob.Id);

        }

        public ItemJob GetItemJobByWorkplaceAndProduct(Workplace workplace, Product product) {
            if (workplace == null) {
                throw new ArgumentException("Workplace is not set");
            }
            if (product == null)
            {
                throw new ArgumentException("Product is not set");
            }

            var allItemJobs = GetAllItemJobs();

            return new List<ItemJob>(from itemJob in allItemJobs where itemJob.Workplace == workplace && itemJob.Product == product select itemJob).FirstOrDefault();
        }

        public ItemJob GetItemJobById(int id)
        {
            if (!_ItemJobCache.ContainsKey(id))
            {
                return null;
            }

            //    ItemJob job = null;
            //    int productId = -1;
            //    int workplaceId = -1;
            //    int nextItemJobId = -1;
            //    using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //    {
            //        conn.Open();

            //        using (var cmd = conn.CreateCommand())
            //        {

            //            cmd.CommandText = "select * from " + Values.ItemJob + " where " + Values.Id + " = " + id;
            //            using (var reader = cmd.ExecuteReader())
            //            {

            //                if (!reader.Read())
            //                {
            //                    return null;
            //                }

            //                job = new ItemJob
            //                {
            //                    Id = (int)reader[Values.Id],
            //                    ProductionTimePerPiece = (double)reader[Values.ProductionTimePerPiece],
            //                    SetupTime = (double)reader[Values.SetupTime]
            //                };

            //                productId = (int)reader[Values.Product_Id];
            //                workplaceId = (int)reader[Values.Workplace_Id];

            //                try
            //                {
            //                    nextItemJobId = (int)reader[Values.NextItemJob_Id];
            //                }
            //                catch (InvalidCastException) { }

            //            }
            //        }
            //    }

            //    job.Product = (Product)GetItemById(productId);
            //    job.Workplace = (Workplace)GetWorkplaceById(workplaceId);
            //    job.Workplace.Jobs.Add(job);

            //    if (nextItemJobId > 0) {
            //        job.NextItemJob = GetItemJobById(nextItemJobId);
            //    }
            //    _ItemJobCache.Add(job.Id, job);
            //}
            return _ItemJobCache[id];
        }

        public void AddChildToProduct(Product product, Item child, int quantity)
        {
            //var dict = new Dictionary<string, object>();

            //dict[Values.Child_Id] = child.Id;
            //dict[Values.Product_Id] = product.Id;
            //dict[Values.Quantity] = quantity;

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = _GenerateInsertFromDict(Values.ChildToProduct, dict);
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            //product = (Product) GetItemById(product.Id);
            //child = GetItemById(child.Id);

            product.AddItem(child, quantity);
        }

        //public void UpdateItem(ref Item item)
        //{

        //    var itemFromDb = GetItemById(item.Id);

        //    if (!_ItemCache.ContainsKey(item.Id))
        //    {
        //        throw new Exception("Item not found");
        //    }

        //    itemFromDb.Description = item.Description;
        //    itemFromDb.Value = item.Value;
        //    itemFromDb.Stock = item.Stock;

        //    if (item is ProcuredItem)
        //    {
        //        var procuredItem = (ProcuredItem) item;
        //        var procuredItemFromDb = (ProcuredItem)itemFromDb;
        //        procuredItemFromDb.DiscountQuantity = procuredItem.DiscountQuantity;
        //        procuredItemFromDb.OrderCosts = procuredItem.OrderCosts;
        //        procuredItemFromDb.ProcureLeadTime = procuredItem.ProcureLeadTime;
        //        procuredItemFromDb.ProcureLeadTimeDeviation = procuredItem.ProcureLeadTimeDeviation;
        //        item = procuredItem;
        //        itemFromDb = procuredItemFromDb;
        //    }

        //    using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = _GenerateUpdateFromDict(Values.Item, item.Id, item.ToDictionary());

        //            cmd.ExecuteNonQuery();

        //        }
        //    }

        //    item = itemFromDb;
        //}

        public void CreateItem(Item item) {

            _ItemCache.Add(item.Id, item);

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = _GenerateInsertFromDict(Values.Item, item.ToDictionary());
            //        cmd.ExecuteNonQuery();

            //    }
            //}
        }

        public void CreateWorkplace(Workplace workplace)
        {
            _WorkplaceCache.Add(workplace.Id, workplace);

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = _GenerateInsertFromDict(Values.Workplace, workplace.ToDictionary());
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public void CreateItemJob(ItemJob itemJob)
        {
            if (itemJob.Workplace != null) {
                itemJob.Workplace.Jobs.Add(itemJob);
            }
            _ItemJobCache.Add(itemJob.Id, itemJob);

            //using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            //{
            //    conn.Open();
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = _GenerateInsertFromDict(Values.ItemJob, itemJob.ToDictionary());
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

    }
}
