using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Purchase>> GetAllPurchases();
        Task<List<string>> AddPurchase(Purchase order);
        Task<List<Order>> GetAllOrders();
        Task<List<string>> AddOrder(Order order);
        Task<List<string>> DeleteOrder(Order order);
        Task<Order?> GetOrderById(string orderId);
    }
}
