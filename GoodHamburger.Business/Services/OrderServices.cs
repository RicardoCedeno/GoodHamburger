using AutoMapper;
using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Business.Contracts.Services;
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

        public async Task<List<string>> AddOrder(Purchase order)
        {
            List<string> rta = [];
            //if (order == null || string.IsNullOrEmpty(order.Id)) return ["La orden no puede ser nula"];
            //if(string.IsNullOrEmpty(order.ProductId)) return 
            return rta;
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

    }
}
