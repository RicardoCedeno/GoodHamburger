using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductsController(IProductServices productServices)
    {
        private readonly IProductServices _productServices = productServices;

        [HttpGet("GetAllSandwiches")]
        public async Task<ResponseDto<List<SandwichDto>>> GetAllSandwiches()
        {
            ResponseDto<List<SandwichDto>> rta = new() { Data = [], IsSuccessful = false, Errors = [] };
            try
            {
                rta.Data = await _productServices.GetAllSandwiches();
                rta.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al obtener los sandwiches {ex.Message}: {ex.InnerException?.Message}"];
            }
            return rta;
        }

        [HttpGet("GetAllExtras")]
        public async Task<ResponseDto<List<ExtraDto>>> GetAllExtras()
        {
            ResponseDto<List<ExtraDto>> rta = new() { Data = [], IsSuccessful = false, Errors = [] };
            try
            {
                rta.Data = await _productServices.GetAllExtras();
                rta.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al obtener los extras {ex.Message}: {ex.InnerException?.Message}"];
            }
            return rta;
        }
    }
}
