using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers.Employee
{
    [Authorize(Roles = "admin,employeecancel")]
    [ApiController]
    [Route("api/orders/cancel")]
    public class OrderCancelController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderCancelController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut]
        public async Task<IActionResult> CancelOrder([FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.CancelOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã hủy đơn hàng." });
        }
    }
}
