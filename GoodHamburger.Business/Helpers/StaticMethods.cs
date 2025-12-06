using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Helpers
{
    public static class StaticMethods
    {
        public static List<string> ValidateOrder(OrderDto order)
        {
            List<string> rta = [];
            #region rule 4
            if (order.Purchases.Any(x => x.Quantity > 1)) rta = ["Only one product per purchase is allowd"];
            if (order.Purchases.Count(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Sandwich.ToUpper().Trim()) != 1) rta = ["Ech order may contain only one sandwich"];
            if (order.Purchases.Count(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Extra.ToUpper().Trim()) > 2) rta = ["No more than two extras alle allowed per order"];
            if (order.Purchases.GroupBy(x => x.ItemTypeId).Select(x => x.Key).ToList().Count < 2) rta = ["The order must include at least one sandwich and one extra"];

            return rta;
            #endregion rule 4
        }

        public static double GetDiscount(OrderDto order)
        {
            double discount = 0;
            #region rule 1
            if (order.Purchases.Where(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Sandwich.ToUpper().Trim()).ToList().Count == 1
                && order.Purchases.Where(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Extra.ToUpper().Trim()).ToList().Count == 2)
            {
                discount = 0.20;
            }
            #region rule 2
            else if (order.Purchases.Where(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Sandwich.ToUpper().Trim()).ToList().Count() == 1
                && order.Purchases.Select(x => x.ProductId.ToUpper().Trim()).Contains(StaticStructs.ProductsId.SoftDrink.ToUpper().Trim()))
            {
                discount = 0.15;
            }
            #endregion rule 1
            #endregion rule 2
            #region rule3
            else if (order.Purchases.Where(x => x.ItemTypeId.ToUpper().Trim() == StaticStructs.ProductTypesId.Sandwich.ToUpper().Trim()).ToList().Count() == 1
                && order.Purchases.Select(x => x.ProductId.ToUpper().Trim()).Contains(StaticStructs.ProductsId.Fries.ToUpper().Trim()))
            {
                discount = 0.10;
            }
            #endregion rule 3
            return discount;
        }

    }
}
