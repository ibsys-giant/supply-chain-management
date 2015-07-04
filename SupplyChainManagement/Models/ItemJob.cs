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
    public class ItemJob : DatabaseObject
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


        public override Dictionary<string, object> ToDictionary()
        {
            var dict = base.ToDictionary();

            dict[Values.Id] = Id;

            if (Workplace != null)
            {
                dict[Values.Workplace_Id] = Workplace.Id;
            }
            if (Product != null)
            {
                dict[Values.Product_Id] = Product.Id;
            }
            if (NextItemJob != null)
            {
                dict[Values.NextItemJob_Id] = NextItemJob.Id;
            }
            dict[Values.SetupTime] = SetupTime;
            dict[Values.ProductionTimePerPiece] = ProductionTimePerPiece;

            return dict;
        }
    }
}
