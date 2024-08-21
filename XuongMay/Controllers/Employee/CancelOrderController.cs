using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers.Employee
{
    [Authorize(Roles = "admin,employee")]
    [ApiController]
    [Route("api/orders/employee/cancel")]
    public class OrderCancelController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderCancelController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // hủy đơn hàng
        [HttpPut]
        public async Task<IActionResult> CancelOrder([FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.CancelOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã hủy đơn hàng." });
        }
    }
}
