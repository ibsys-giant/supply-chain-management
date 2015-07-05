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

                    var order = ProductionOrders[job.Product];
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
            var overtime = TotalCapacityRequirements[workplace] - Constants.SHIFT_DURATION;
            if (overtime <= 0.0)
            {
                Shifts[workplace] = 1;
                Overtime[workplace] = 0.0;
                return;
            }

            var shiftCosts = new Dictionary<int, double>();
            shiftCosts.Add(1, workplace.LaborCostsFirstShift);
            shiftCosts.Add(2, workplace.LaborCostsSecondShift);
            shiftCosts.Add(3, workplace.LaborCostsThirdShift);

            Shifts[workplace] = 1;

            while ((Constants.SHIFT_DURATION - overtime) > 0.0 && Shifts[workplace] < 3)
            {
                var overtimeCosts = overtime * workplace.LaborCostsOvertime;
                var additionalShiftCosts = Constants.SHIFT_DURATION * shiftCosts[Shifts[workplace] + 1];

                if (additionalShiftCosts < overtimeCosts)
                {
                    Shifts[workplace]++;
                    overtime -= Constants.SHIFT_DURATION;
                }
                else {
                    break;
                }
            }


            if (overtime <= 0.0)
            {
                Overtime[workplace] = 0.0;
            }
            else {
                Overtime[workplace] = overtime;
            }

        }
    }
}
