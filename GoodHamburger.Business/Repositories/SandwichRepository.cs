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
    public class SandwichRepository(Context context, IMapper mapper) : ISandwichRepository
    {
        private readonly Context _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<SandwichDto>> GetAllSandwiches()
        {
            List<SandwichDto> rta = [];
            List<Sandwich> sandwiches = [.. await _context.Sandwiches.ToListAsync()];
            rta = _mapper.Map<List<SandwichDto>>(sandwiches);
            return rta;
        }
    }
}
