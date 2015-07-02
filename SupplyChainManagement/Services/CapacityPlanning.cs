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
    public class CapacityPlanning : MaterialPlanning
    {
        public Dictionary<Workplace, double> TotalCapacityRequirements = new Dictionary<Workplace, double>();
        public Dictionary<Workplace, double> Overtime = new Dictionary<Workplace, double>();

        public CapacityPlanning(MaterialPlanning planning) : base(planning.DataSource) {
            this.ProductionOrders = planning.ProductionOrders;
        }

        public CapacityPlanning CreateWorkRequirements() {
            TotalCapacityRequirements = new Dictionary<Workplace, double>();

            foreach (var workplace in DataSource.GetAllWorkplaces()) {

                var totalSetupTime = 0.0;
                foreach (var job in workplace.Jobs) {

                    var order = ProductionOrders[job.Product];
                    var timePerPiece = job.ProductionTimePerPiece;
                    var totalItemWorkRequirement =  order * timePerPiece;
                    if (TotalCapacityRequirements.ContainsKey(workplace))
                    {
                        TotalCapacityRequirements[workplace] += totalItemWorkRequirement;
                    }
                    else
                    {
                        TotalCapacityRequirements[workplace] = totalItemWorkRequirement;
                    }

                    totalSetupTime += job.SetupTime;
                }

                TotalCapacityRequirements[workplace] += totalSetupTime;

                // TODO add time backlog previous period
                // TODO add setup time backlog previous period

                var overtime = TotalCapacityRequirements[workplace] - 2400.0;

                if (overtime > 0) 
                {
                    Overtime[workplace] = overtime;
                }
                else
                {
                    Overtime[workplace] = 0.0;
                }
            }
            return this;
        }
    }
}
