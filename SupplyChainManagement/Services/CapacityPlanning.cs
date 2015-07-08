using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SupplyChainManagement;
using SupplyChainManagement.Models;
using SupplyChainManagement.Data;
using SupplyChainManagement.Util;

namespace SupplyChainManagement.Services
{
    public class CapacityPlanning : MaterialPlanning
    {
        public Dictionary<Workplace, double> AdditionalCapacityRequirements = new Dictionary<Workplace, double>();
        public Dictionary<Workplace, double> TotalCapacityRequirements = new Dictionary<Workplace, double>();

        public Dictionary<Workplace, int> Shifts = new Dictionary<Workplace, int>();
        public Dictionary<Workplace, double> Overtime = new Dictionary<Workplace, double>();

        public CapacityPlanning(MaterialPlanning planning, Dictionary<Workplace, double> additionalCapacityRequirements) : base(planning.DataSource, planning.WaitingList, planning.OrdersInWork) {
            this.ProductionOrders = planning.ProductionOrders;
            this.AdditionalCapacityRequirements = additionalCapacityRequirements;
        }

        public CapacityPlanning CreateWorkRequirements() {
            TotalCapacityRequirements = new Dictionary<Workplace, double>();

            foreach (var workplace in DataSource.GetAllWorkplaces()) {

                var totalSetupTime = 0.0;

                if (!TotalCapacityRequirements.ContainsKey(workplace))
                {
                    TotalCapacityRequirements[workplace] = 0.0;
                }

                foreach (var job in workplace.Jobs) {

                    var order = ProductionOrders[0][job.Product];
                    var timePerPiece = job.ProductionTimePerPiece;
                    var totalItemWorkRequirement =  order * timePerPiece;
                    TotalCapacityRequirements[workplace] += totalItemWorkRequirement;
                    totalSetupTime += job.SetupTime;
                }

                TotalCapacityRequirements[workplace] += totalSetupTime;

                if (AdditionalCapacityRequirements.ContainsKey(workplace)) 
                {
                    TotalCapacityRequirements[workplace] += AdditionalCapacityRequirements[workplace];
                }

                _CalculateOvertimeAndShifts(workplace);
            }
            return this;
        }

        private void _CalculateOvertimeAndShifts(Workplace workplace) 
        {
            var capacityRequirements = TotalCapacityRequirements[workplace] / 5.0;
            var shiftDuration = Constants.SHIFT_DURATION / 5.0;
            var overtime = (capacityRequirements - shiftDuration);
            Shifts[workplace] = 1;

            while (overtime >= shiftDuration)
            {
                Shifts[workplace]++;
                overtime -= Shifts[workplace];
            }

            if (Shifts[workplace] > 3) {
                Shifts[workplace] = 3;
                overtime = shiftDuration;
            }

            if (overtime < 0)
            {
                overtime = 0.0;
            }
            Overtime[workplace] = overtime;
        }
    }
}
