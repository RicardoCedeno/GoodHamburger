using GoodHamburger.Business.Contracts.Services;
using GoodHamburger.Business.Services;
using GoodHamburger.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController(IOrderServices orderServices)
    {
        private readonly IOrderServices _orderServices = orderServices;

        [HttpGet("GetOrderServices")]
        public async Task<ResponseDto<List<OrderDto>>> GetAllOrders()
        {
            ResponseDto<List<OrderDto>> rta = new() { Data = [], IsSuccessful = false, Errors = [] };
            try
            {
                rta.Data = await _orderServices.GetAllOrders();
                rta.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al obtener las ordenes {ex.Message}: {ex.InnerException?.Message}"];
            }
            return rta;
        }
    }
}
