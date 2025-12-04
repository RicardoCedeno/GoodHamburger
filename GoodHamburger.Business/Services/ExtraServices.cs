using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Services
{
    public class ExtraServices(IExtraRepository extraRepository) : IExtraServices
    {
        private readonly IExtraRepository _extraRepository = extraRepository;
        public async Task<List<ExtraDto>> GetAllExtras()
        {
            List<ExtraDto> rta = [];
            rta = await _extraRepository.GetAllExtras();
            return rta;
        }
    }
}
