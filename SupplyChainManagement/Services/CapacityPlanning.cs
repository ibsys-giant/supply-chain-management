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

        public CapacityPlanning(MaterialPlanning planning) : base(planning.DataSource) {
            this.ProductionOrders = planning.ProductionOrders;
        }

        public CapacityPlanning CreateWorkRequirements() {
            TotalCapacityRequirements = new Dictionary<Workplace, double>();

            foreach (var workplace in DataSource.Workplaces.Values) {
                foreach (var job in workplace.Jobs) {

                    var order = ProductionOrders[job.Item];
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

                    TotalCapacityRequirements[workplace] += job.SetupTime;
                }

                // TODO add time backlog previous period
                // TODO add setup time backlog previous period
            }
            return this;
        }
    }
}
