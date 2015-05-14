using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Data
{
    public interface DataSource
    {
        Dictionary<int, Item> Items
        {
            get;
        }
        Dictionary<int, Workplace> Workplaces
        {
            get;
        }

        Dictionary<int, ItemJob> ItemJobs
        {
            get;
        }

        void AddNewItem(Item item);
        void AddNewWorkplace(Workplace workplace);
        void AddNewItemJob(ItemJob itemJob);

    }
}
