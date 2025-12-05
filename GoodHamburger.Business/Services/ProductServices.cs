using AutoMapper;
using GoodHamburger.Business.Contracts.Repositories;
using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Business.Repositories;
using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Services
{
    public class ProductServices(IProductRepository productRepository, IMapper mapper) : IProductServices
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;
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

        public async Task<List<GenericProductDto>> GetAllProducts()
        {
            List<GenericProductDto> rta = [];
            List<SandwichDto> sandwiches = await GetAllSandwiches();
            List<ExtraDto> extras = await GetAllExtras();
            List<GenericProductDto> sandwichesProducts = _mapper.Map<List<GenericProductDto>>(sandwiches);
            List<GenericProductDto> extraProducts = _mapper.Map<List<GenericProductDto>>(extras);
            rta = [.. sandwichesProducts.Union(extraProducts).OrderBy(x => x.Name)];
            return rta;
        }
    }
}
