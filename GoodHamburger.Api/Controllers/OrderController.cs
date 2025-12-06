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

        /// <summary>
        /// Get all orders and their purchases
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrders")]
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
        /// <summary>
        /// Add an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("AddOrder")]
        public async Task<ResponseDto<int>> AddOrder([FromBody] OrderDto order)
        {
            ResponseDto<int> rta = new() { Data = 0, Errors = [], IsSuccessful = false, Others = 0 };
            try
            {
                (List<string>, double) response = await _orderServices.AddOrder(order);
                rta.Errors = response.Item1;
                rta.IsSuccessful = true;
                rta.Data = 1;
                rta.Others = response.Item2;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al agregar las ordenes {ex.Message}: {ex.InnerException?.Message}"];
                rta.Data = 0;
            }
            return rta;
        }

        /// <summary>
        /// Delete an order using the Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrder/{orderId}")]
        public async Task<ResponseDto<int>> DeleteOrder([FromRoute] string orderId)
        {
            ResponseDto<int> rta = new() { Data = 0, Errors = [], IsSuccessful = false };
            try
            {
                rta.Errors = await _orderServices.DeleteOrder(orderId);
                rta.IsSuccessful = true;
                rta.Data = 1;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al eliminar la orden {ex.Message}: {ex.InnerException?.Message}"];
                rta.Data = 0;
            }
            return rta;
        }

        /// <summary>
        /// Update and order using an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("UpdateOrder")]
        public async Task<ResponseDto<int>> UpdateOrder([FromBody] OrderDto order)
        {
            ResponseDto<int> rta = new() { Data = 0, Errors = [], IsSuccessful = false };
            try
            {
                rta.Errors = await _orderServices.UpdateOrder(order);
                rta.IsSuccessful = true;
                rta.Data = 1;
            }
            catch (Exception ex)
            {
                rta.IsSuccessful = false;
                rta.Errors = [$"Ocurrieron los siguientes errores al actualizar la ordern {ex.Message}: {ex.InnerException?.Message}"];
                rta.Data = 0;
            }
            return rta;
        }
    }
}
