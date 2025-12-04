using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Business.Repositories;
using GoodHamburger.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Services
{
    public class ProductServices(IProductRepository productRepository) : IProductServices
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<List<ExtraDto>> GetAllExtras()
        {
            List<ExtraDto> rta = [];
            rta = await _productRepository.GetAllExtras();
            return rta;
        }

        public async Task<List<SandwichDto>> GetAllSandwiches()
        {
            List<SandwichDto> rta = [];
            rta = await _productRepository.GetAllSandwiches();
            return rta;
        }
    }
}
