using AutoMapper;
using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Business.Helpers;
using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Services
{
    public class OrderServices(IOrderRepository orderRepository, IProductRepository productRepository, IProductServices productServices, IMapper mapper) : IOrderServices
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductServices _productServices = productServices;
        private readonly IMapper _mapper = mapper;

        public async Task<(List<string>, double)> AddOrder(OrderDto order)
        {
            List<string> rta = [];
            Order finalOrder = new();
            double discount = 0;
            if (order == null) return (["Order can't be null or empty"], 0);
            if (order.Purchases == null || !order.Purchases.Any()) return (["The order must contain purchases"], 0);

            List<GenericProductDto> genericProducts = await _productServices.GetAllProducts();

            #region rule 4
            List<string> orderValidations = StaticMethods.ValidateOrder(order);
            if (orderValidations.Any()) return (orderValidations, 0);
            #endregion rule 4
            #region rule 1, rule 2, rule 3
            discount = StaticMethods.GetDiscount(order);
            #endregion rule 1, rule 2, rule 3

            finalOrder.Id = Guid.NewGuid().ToString();
            foreach (PurchaseDto item in order.Purchases)
            {
                double unitPrice = genericProducts.FirstOrDefault(x => x.Id.ToUpper().Trim() == item.ProductId.ToUpper().Trim())?.Price ?? 0;
                Purchase purchase = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = item.ProductId,
                    ItemTypeId = item.ItemTypeId,
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    UnitPrice = unitPrice,
                    SubTotal = unitPrice * item.Quantity,
                };
                purchase.ItemType = null!;
                finalOrder.Purchases.Add(purchase);
                finalOrder.Total += purchase.SubTotal * (1-discount);

            }
            await _orderRepository.AddOrder(finalOrder);
            return (rta, finalOrder.Total);
        }

        public async Task<List<string>> DeleteOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return ["The order id to remove can't be null or empty"];
            Order? order = await _orderRepository.GetOrderById(orderId);
            if (order == null) return ["The order you are trying to remove doesn't exist"];
            return await _orderRepository.DeleteOrder(order);
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            List<OrderDto> rta = [];
            List<GenericProductDto> allProducts = await _productServices.GetAllProducts();
            List<Order> orders = await _orderRepository.GetAllOrders();
            List<Purchase> purchases = await _orderRepository.GetAllPurchases();
            if (!purchases.Any()) throw new Exception("No hay compras agregadas aún");
            if (!orders.Any()) throw new Exception("No hay ordenes agregadas aún");
            List<ItemType> itemTypes = await _productRepository.GetItemTypes();
            rta = [..(from order in orders
                   join purchase in purchases on order.Id.ToUpper().Trim() equals purchase.OrderId.ToUpper().Trim()
                   join product in allProducts on purchase.ProductId.ToUpper().Trim() equals product.Id.ToUpper().Trim()
                   join itemType in itemTypes on product.Type.ToUpper().Trim() equals itemType.ItemName.ToUpper().Trim()
                   select new OrderDto
                   {
                       Id = order.Id,
                       Total = order.Total,
                       Purchases = (_mapper.Map<List<PurchaseDto>>(purchases)).Where(x=>x.OrderId.ToUpper().Trim() == order.Id.ToUpper().Trim()).ToList(),
                   })];
            return rta;

        }

        public async Task<List<string>> UpdateOrder(OrderDto order)
        {
            List<string> rta = [];
            List<string> validations = [];
            double discount = 0;
            if (order == null) return ["Order can't be null"];
            if (order.Purchases == null || !order.Purchases.Any()) return ["The order doesn't contain purchases"];

            Order? existingOrder = await _orderRepository.GetOrderById(order.Id);
            if (existingOrder == null) return ["The order you are trying to update doesn't exist"];
            List<GenericProductDto> genericProducts = await _productServices.GetAllProducts();

            List<Purchase>? purchasesToDelete = existingOrder.Purchases.Where(x => !order.Purchases.Any(y => y.Id.ToUpper().Trim() == x.Id.ToUpper().Trim())).ToList();
            if (purchasesToDelete.Any())
            {
                foreach(Purchase purchase in purchasesToDelete)
                {
                    existingOrder.Purchases.Remove(purchase);
                }
            }
            existingOrder.Total = 0;
            foreach(PurchaseDto item in order.Purchases)
            {
                Purchase? existingPurchase = existingOrder.Purchases.FirstOrDefault(x => x.Id.ToUpper().Trim() ==  item.Id.ToUpper().Trim());
                double unitPrice = genericProducts.FirstOrDefault(x => x.Id.ToUpper().Trim() == item.ProductId.ToUpper().Trim())?.Price ?? 0;
                double subTotal = unitPrice * item.Quantity * (1 - discount);

                if(existingPurchase != null)
                {
                    existingPurchase.ProductId = item.ProductId;
                    existingPurchase.ItemTypeId = item.ItemTypeId;
                    existingPurchase.Quantity = item.Quantity;
                    existingPurchase.UnitPrice = unitPrice;
                    existingPurchase.SubTotal = subTotal;
                }
                else
                {
                    Purchase newPurchase = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = item.ProductId,
                        ItemTypeId = item.ItemTypeId,
                        Quantity = item.Quantity,
                        UnitPrice = unitPrice,
                        SubTotal = subTotal,
                        OrderId = existingOrder.Id
                    };
                    newPurchase.ItemType = null!;
                    existingOrder.Purchases.Add(newPurchase);
                }
                existingOrder.Total += subTotal;
            }
            #region rule 4
            OrderDto existingOrderDto = _mapper.Map<OrderDto>(existingOrder);
            List<string> orderValidations = StaticMethods.ValidateOrder(existingOrderDto);
            if (orderValidations.Any()) return orderValidations;
            #endregion rule 4
            #region rule 1, rule 2, rule 3
            discount = StaticMethods.GetDiscount(existingOrderDto);
            #endregion rule 1, rule 2, rule 3
            await _orderRepository.UpdateOrder(existingOrder);

            return rta;
        }

    }
}
