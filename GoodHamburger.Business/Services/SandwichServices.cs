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
    public class SandwichServices(ISandwichRepository sandwichRepository) : ISandwichServices
    {
        private readonly ISandwichRepository _sandwichRepository = sandwichRepository;

        public async Task<List<SandwichDto>> GetAllSandwiches()
        {
            List<SandwichDto> rta = [];
            rta = await _sandwichRepository.GetAllSandwiches();
            return rta;
        }
    }
}
