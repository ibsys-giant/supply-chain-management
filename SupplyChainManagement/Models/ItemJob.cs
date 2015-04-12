using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    class ItemJob
    {

        public int Id;

        /// <summary>
        /// The workplace where this item is in work
        /// </summary>
        public Workplace Workplace;

        /// <summary>
        /// Item to be produced during the job
        /// </summary>
        public ProducedItem Item;

        /// <summary>
        /// Setup time to switch to another part
        /// </summary>
        public double SetupTime;

        /// <summary>
        /// Production time per piece in minutes
        /// </summary>
        public double ProductionTimePerPiece;
    }
}
