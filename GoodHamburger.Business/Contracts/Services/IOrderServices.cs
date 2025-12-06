using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Contracts.Services
{
    public interface IOrderServices
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<(List<string>, double)> AddOrder(OrderDto order);
        Task<List<string>> DeleteOrder(string orderId);
        Task<List<string>> UpdateOrder(OrderDto order);
    }
}
