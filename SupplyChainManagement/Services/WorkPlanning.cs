using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SupplyChainManagement;
using SupplyChainManagement.Models;
using SupplyChainManagement.Data;

namespace SupplyChainManagement.Services
{
    public class WorkPlanning : MaterialPlanning
    {

        public WorkPlanning(MaterialPlanning planning) : base(planning.DataSource) {
            this.ProductionOrders = planning.ProductionOrders;
        }
    }
}
