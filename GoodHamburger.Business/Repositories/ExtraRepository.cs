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
    public class ExtraRepository(Context context, IMapper mapper) : IExtraRepository
    {
        private readonly Context _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ExtraDto>> GetAllExtras()
        {
            List<ExtraDto> rta = [];
            List<Extra> extras = await _context.Extras.ToListAsync();
            rta = _mapper.Map<List<ExtraDto>>(extras);
            return rta;

        }
    }
}
