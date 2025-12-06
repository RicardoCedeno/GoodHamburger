using AutoMapper;
using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Data;
using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Repositories
{
    public class OrderRepository(Context context): IOrderRepository
    {
        private readonly Context _context = context;

        public async Task<List<Purchase>> GetAllPurchases()
        {
            List<Purchase> rta = [];
            rta = await _context.Purchases.ToListAsync();
            return rta;
        }

        public async Task<List<string>> AddPurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            int response = await _context.SaveChangesAsync();
            return response > 0 ? [] : ["Ocurrió un error al agregar la orden"];
        }

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> rta = await _context.Orders.ToListAsync();
            return rta;
        }

        public async Task<List<string>> AddOrder(Order order)
        {
            List<string> rta = [];
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync() > 0 ? [] : ["Ocurrió un error al agregar la orden. Código error: XXX"];
        }

        public async Task<List<string>> DeleteOrder(Order order)
        {
            List<string> rta = [];
            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() > 0 ? [] : ["Ocurrió un error al eliminar la orden. Código error: XXX"];
        }

        public async Task<Order?> GetOrderById(string orderId)
        {
            return await _context.Orders.Include(y=>y.Purchases).FirstOrDefaultAsync(x => x.Id.ToUpper().Trim() == orderId.ToUpper().Trim());
        }

        public async Task<List<string>> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync() > 0 ? [] : ["Ocurrió un error al actualizar la orden. Código error: XXX"];
        }

        public async Task<List<string>> UpdatePurchase(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            return await _context.SaveChangesAsync() > 0 ? [] : ["Ocurrió un error al actualizar la compra. Código error: XXX"];
        }
    }
}
