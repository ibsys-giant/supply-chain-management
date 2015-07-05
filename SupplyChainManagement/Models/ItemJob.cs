using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Util;

using SupplyChainManagement.Data;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Models
{
    public class ItemJob
    {

        public int Id;

        /// <summary>
        /// The workplace where this item is in work
        /// </summary>
        public Workplace Workplace;

        /// <summary>
        /// Product to be produced during the job
        /// </summary>
        public Product Product;

        /// <summary>
        /// Setup time to switch to another part
        /// </summary>
        public double SetupTime;

        /// <summary>
        /// Production time per piece in minutes
        /// </summary>
        public double ProductionTimePerPiece;

        /// <summary>
        /// Next item job
        /// </summary>
        public ItemJob NextItemJob;


    }
}
