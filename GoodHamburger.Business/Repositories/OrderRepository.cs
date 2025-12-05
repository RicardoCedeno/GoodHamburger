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
    public class OrderRepository(Context context, IProductRepository productRepository, IMapper mapper): IOrderRepository
    {
        private readonly Context _context = context;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> rta = [];
            rta = await _context.Orders.ToListAsync();
            return rta;
        }
    }
}
