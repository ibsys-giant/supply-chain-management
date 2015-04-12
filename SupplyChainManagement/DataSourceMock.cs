using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models;

namespace SupplyChainManagement
{
    class DataSourceMock
    {
        private int itemIdSeq = 0;
        public Dictionary<int, Item> Items = new Dictionary<int,Item>();

        private int workplaceIdSeq = 0;
        public Dictionary<int, Workplace> Workplaces = new Dictionary<int, Workplace>();

        private int itemJobIdSeq = 0;
        public Dictionary<int, ItemJob> ItemJobs = new Dictionary<int, ItemJob>();

        public DataSourceMock() {

            // Create mock items
            AddNewItem(new ProductItem { Value = 156.13, Stock = 100 });
            AddNewItem(new ProductItem { Value = 163.33, Stock = 100 });
            AddNewItem(new ProductItem { Value = 165.08, Stock = 100 });
            AddNewItem(new ProducedItem { Value = 40.85, Stock = 100 });
            AddNewItem(new ProducedItem { Value = 39.85, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 40.85, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 35.85, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 35.85, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 35.85, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 12.40, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 14.65, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 14.65, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 12.40, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 14.65, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 14.65, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 7.02, Stock = 300  });
            AddNewItem(new ProducedItem { Value = 1.16, Stock = 300  });
            AddNewItem(new ProducedItem { Value = 13.15, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 14.35, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 15.55, Stock = 100  });
            AddNewItem(new ProcurementItem { Value = 5.0, Stock = 300, OrderCosts = 1.8, ProcureLeadTime= 1.8, ProcureLeadTimeDeviation=0.4  });
            AddNewItem(new ProcurementItem { Value = 6.5, Stock = 300, OrderCosts = 1.7, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.4 });
            AddNewItem(new ProcurementItem { Value = 6.5, Stock = 300, OrderCosts = 1.2, ProcureLeadTime=1.2 , ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProcurementItem { Value = 0.06, Stock = 6100, OrderCosts = 3.2, ProcureLeadTime=3.2 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 0.06, Stock = 3600, OrderCosts = 0.9, ProcureLeadTime=0.9 , ProcureLeadTimeDeviation=0.2  });
            AddNewItem(new ProducedItem { Value = 10.5, Stock = 300  });
            AddNewItem(new ProcurementItem { Value = 0.1, Stock = 1800, OrderCosts = 0.9, ProcureLeadTime=0.9 , ProcureLeadTimeDeviation=0.2});
            AddNewItem(new ProcurementItem { Value = 1.2, Stock = 4500, OrderCosts = 1.7, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.4 });
            AddNewItem(new ProducedItem { Value = 69.29, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 127.53, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 144.42, Stock = 100  });
            AddNewItem(new ProcurementItem { Value = 0.75, Stock = 2700, OrderCosts = 2.1, ProcureLeadTime=2.1 , ProcureLeadTimeDeviation=0.5 });
            AddNewItem(new ProcurementItem { Value = 22.0, Stock = 900, OrderCosts = 1.9, ProcureLeadTime=1.9 , ProcureLeadTimeDeviation=0.5 });
            AddNewItem(new ProcurementItem { Value = 0.1, Stock = 22000, OrderCosts = 1.6, ProcureLeadTime=1.6 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 1.0, Stock = 3600, OrderCosts = 2.2, ProcureLeadTime=2.2 , ProcureLeadTimeDeviation=0.4 });
            AddNewItem(new ProcurementItem { Value = 8.0, Stock = 900, OrderCosts = 1.2, ProcureLeadTime=1.2 , ProcureLeadTimeDeviation=0.1 });
            AddNewItem(new ProcurementItem { Value = 1.5, Stock = 900, OrderCosts = 1.5, ProcureLeadTime=1.5 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 1.5, Stock = 300, OrderCosts = 1.7, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.4 });
            AddNewItem(new ProcurementItem { Value = 1.5, Stock = 900, OrderCosts = 1.5, ProcureLeadTime=1.5 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 2.5, Stock = 900, OrderCosts = 1.7, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProcurementItem { Value = 0.06, Stock = 900, OrderCosts = 0.9, ProcureLeadTime=0.9 , ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProcurementItem { Value = 0.1, Stock = 1800, OrderCosts = 1.2, ProcureLeadTime=1.2 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 5.0, Stock = 1900, OrderCosts = 2.0, ProcureLeadTime=2.0 , ProcureLeadTimeDeviation=0.5 });
            AddNewItem(new ProcurementItem { Value = 0.5, Stock = 270, OrderCosts = 1.0, ProcureLeadTime=1.0 , ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProcurementItem { Value = 0.06, Stock = 900, OrderCosts = 1.7, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 0.1, Stock = 900, OrderCosts = 0.9, ProcureLeadTime=0.9 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 3.5, Stock = 900, OrderCosts = 1.41, ProcureLeadTime=1.41,  ProcureLeadTimeDeviation=0.1 });
            AddNewItem(new ProcurementItem { Value = 1.5, Stock = 1800, OrderCosts = 1.0, ProcureLeadTime=1.0, ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProducedItem { Value = 64.64, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 120.63, Stock = 100  });
            AddNewItem(new ProcurementItem { Value = 137.47, Stock = 100, OrderCosts = 1.6, ProcureLeadTime=1.6 , ProcureLeadTimeDeviation=0.4 });
            AddNewItem(new ProcurementItem { Value = 22.0, Stock = 600, OrderCosts = 1.6, ProcureLeadTime=1.6 , ProcureLeadTimeDeviation=0.2 });
            AddNewItem(new ProducedItem { Value = 0.1, Stock = 22000  });
            AddNewItem(new ProducedItem { Value = 68.09, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 125.33, Stock = 100  });
            AddNewItem(new ProducedItem { Value = 142.67, Stock = 100 });
            AddNewItem(new ProcurementItem { Value = 22.0, Stock = 600, OrderCosts = 0.3, ProcureLeadTime=1.7 , ProcureLeadTimeDeviation=0.3 });
            AddNewItem(new ProcurementItem { Value = 0.1, Stock = 22000, OrderCosts = 0.5, ProcureLeadTime=1.6 , ProcureLeadTimeDeviation=0.5 });
            AddNewItem(new ProcurementItem { Value = 0.15, Stock = 1800, OrderCosts = 0.2, ProcureLeadTime=0.7 , ProcureLeadTimeDeviation=0.2 });
            Console.WriteLine(Items.Count + " Items added");

            // Create mock workplaces
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            AddNewWorkplace(new Workplace { });
            Console.WriteLine(Workplaces.Count + " Workplaces added");

            // Add mock jobs
            AddNewItemJob(new ItemJob { Item = Items[1] as ProducedItem, Workplace = Workplaces[4], ProductionTimePerPiece = 6, SetupTime = 30.0 });
            //..
            Console.WriteLine(ItemJobs.Count + " ItemJobs added");
        }

        public void AddNewItem(Item item) {
            item.Id = ++itemIdSeq;
            Items.Add(item.Id, item);
        }

        public void AddNewWorkplace(Workplace workplace)
        {
            workplace.Id = ++workplaceIdSeq;
            Workplaces.Add(workplace.Id, workplace);
        }

        public void AddNewItemJob(ItemJob job)
        {
            job.Id = ++itemJobIdSeq;
            ItemJobs.Add(job.Id, job);
        }
    }
}
