using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using SupplyChainManagement.Data;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Util
{
    public class BillOfMaterialUtil
    {

        public static Dictionary<Item, int> CreateBillOfMaterial(Product product)
        {
            return CreateBillOfMaterial(1, product, new Dictionary<Item, int>());
        }

        public static Dictionary<Item, int> CreateBillOfMaterial(int parentQuantity, Product product, Dictionary<Item, int> bom)
        {
            foreach (Item child in product.Items)
            {
                var total = parentQuantity * product.ItemQuantities[child];
                if (bom.ContainsKey(child))
                {
                    bom[child] += total;
                }
                else
                {
                    bom.Add(child, total);
                }

                if (child is Product)
                {
                    CreateBillOfMaterial(product.ItemQuantities[child], child as Product, bom);
                }
            }
            return bom;
        }

        public static List<Product> CreateWhereUsedList(Item item)
        {
            return _CreateWhereUsedList(item, new List<Product>());
        }

        private static List<Product> _CreateWhereUsedList(Item item, List<Product> whereUsedList)
        {

            foreach (Product p in item.UsedInProducts)
            {
                if (!whereUsedList.Contains(p)) {
                    whereUsedList.Add(p);
                }

                _CreateWhereUsedList(p, whereUsedList);
            }
            return whereUsedList;
        }
    }
}
