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
        public List<Item> Items;

        public DataSourceMock() {
            Items = new List<Item>();
            Items.Add(new ProductItem{Id=1, Value=156.13, Stock=100 });
            Items.Add(new ProductItem{Id=2, Value=163.33, Stock=100 });
            Items.Add(new ProductItem{Id=3, Value=165.08, Stock=100 });
            Items.Add(new ProducedItem{Id=4, Value=40.85, Stock=100 });
            Items.Add(new ProducedItem{Id = 5, Value = 39.85, Stock=100  });
            Items.Add(new ProducedItem { Id = 6, Value = 40.85, Stock=100  });
            Items.Add(new ProducedItem { Id = 7, Value = 35.85, Stock=100  });
            Items.Add(new ProducedItem { Id = 8, Value = 35.85, Stock=100  });
            Items.Add(new ProducedItem { Id = 9, Value = 35.85, Stock=100  });
            Items.Add(new ProducedItem { Id = 10, Value = 12.40, Stock=100  });
            Items.Add(new ProducedItem { Id = 11, Value = 14.65, Stock=100  });
            Items.Add(new ProducedItem { Id = 12, Value = 14.65, Stock=100  });
            Items.Add(new ProducedItem { Id = 13, Value = 12.40, Stock=100  });
            Items.Add(new ProducedItem { Id = 14, Value = 14.65, Stock=100  });
            Items.Add(new ProducedItem { Id = 15, Value = 14.65, Stock=100  });
            Items.Add(new ProducedItem { Id = 16, Value = 7.02, Stock=300  });
            Items.Add(new ProducedItem { Id = 17, Value = 1.16, Stock=300  });
            Items.Add(new ProducedItem { Id = 18, Value = 13.15, Stock=100  });
            Items.Add(new ProducedItem { Id = 19, Value = 14.35, Stock=100  });
            Items.Add(new ProducedItem { Id = 20, Value = 15.55, Stock=100  });
            Items.Add(new ProcurementItem { Id = 21, Value = 5.0, Stock=300, OrderCosts=1.8, ProcureLeadTimeDeviation=0.4  });
            Items.Add(new ProcurementItem { Id = 22, Value = 6.5, Stock = 300, OrderCosts = 1.7, ProcureLeadTimeDeviation=0.4 });
            Items.Add(new ProcurementItem { Id = 23, Value = 6.5, Stock = 300, OrderCosts = 1.2, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProcurementItem { Id = 24, Value = 0.06, Stock = 6100, OrderCosts = 3.2, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 25, Value = 0.06, Stock=3600, OrderCosts=0.9, ProcureLeadTimeDeviation=0.2  });
            Items.Add(new ProducedItem { Id = 26, Value = 10.5, Stock=300  });
            Items.Add(new ProcurementItem { Id = 27, Value = 0.1, Stock = 1800, OrderCosts = 0.9, ProcureLeadTimeDeviation=0.2});
            Items.Add(new ProcurementItem { Id = 28, Value = 1.2, Stock=4500, OrderCosts=1.7, ProcureLeadTimeDeviation=0.4 });
            Items.Add(new ProducedItem { Id = 29, Value = 69.29, Stock=100  });
            Items.Add(new ProducedItem { Id = 30, Value = 127.53, Stock=100  });
            Items.Add(new ProducedItem { Id = 31, Value = 144.42, Stock=100  });
            Items.Add(new ProcurementItem { Id = 32, Value = 0.75, Stock = 2700, OrderCosts = 2.1, ProcureLeadTimeDeviation=0.5 });
            Items.Add(new ProcurementItem { Id = 33, Value = 22.0, Stock = 900, OrderCosts = 1.9, ProcureLeadTimeDeviation=0.5 });
            Items.Add(new ProcurementItem { Id = 34, Value = 0.1, Stock = 22000, OrderCosts = 1.6, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 35, Value = 1.0, Stock = 3600, OrderCosts = 2.2, ProcureLeadTimeDeviation=0.4 });
            Items.Add(new ProcurementItem { Id = 36, Value = 8.0, Stock = 900, OrderCosts = 1.2, ProcureLeadTimeDeviation=0.1 });
            Items.Add(new ProcurementItem { Id = 37, Value = 1.5, Stock = 900, OrderCosts = 1.5, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 38, Value = 1.5, Stock = 300, OrderCosts = 1.7, ProcureLeadTimeDeviation=0.4 });
            Items.Add(new ProcurementItem { Id = 39, Value = 1.5, Stock = 900, OrderCosts = 1.5, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 40, Value = 2.5, Stock = 900, OrderCosts = 1.7, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProcurementItem { Id = 41, Value = 0.06, Stock = 900, OrderCosts = 0.9, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProcurementItem { Id = 42, Value = 0.1, Stock = 1800, OrderCosts = 1.2, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 43, Value = 5.0, Stock = 1900, OrderCosts = 2.0, ProcureLeadTimeDeviation=0.5 });
            Items.Add(new ProcurementItem { Id = 44, Value = 0.5, Stock = 270, OrderCosts = 1.0, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProcurementItem { Id = 45, Value = 0.06, Stock = 900, OrderCosts = 1.7, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 46, Value = 0.1, Stock = 900, OrderCosts = 0.9, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 47, Value = 3.5, Stock = 900, OrderCosts = 1.41, ProcureLeadTimeDeviation=0.1 });
            Items.Add(new ProcurementItem { Id = 48, Value = 1.5, Stock = 1800, OrderCosts = 1.0, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProducedItem { Id = 49, Value = 64.64, Stock=100  });
            Items.Add(new ProducedItem { Id = 50, Value = 120.63, Stock=100  });
            Items.Add(new ProcurementItem { Id = 51, Value = 137.47, Stock = 100, OrderCosts = 1.6, ProcureLeadTimeDeviation=0.4 });
            Items.Add(new ProcurementItem { Id = 52, Value = 22.0, Stock = 600, OrderCosts = 1.6, ProcureLeadTimeDeviation=0.2 });
            Items.Add(new ProducedItem { Id = 53, Value = 0.1, Stock=22000  });
            Items.Add(new ProducedItem { Id = 54, Value = 68.09, Stock=100  });
            Items.Add(new ProducedItem { Id = 55, Value = 125.33, Stock=100  });
            Items.Add(new ProducedItem { Id = 56, Value = 142.67, Stock = 100 });
            Items.Add(new ProcurementItem { Id = 57, Value = 22.0, Stock = 600, OrderCosts = 0.3, ProcureLeadTimeDeviation=0.3 });
            Items.Add(new ProcurementItem { Id = 58, Value = 0.1, Stock = 22000, OrderCosts = 0.5, ProcureLeadTimeDeviation=0.5 });
            Items.Add(new ProcurementItem { Id = 50, Value = 0.15, Stock = 1800, OrderCosts = 0.2, ProcureLeadTimeDeviation=0.2 });
        }
    }
}
