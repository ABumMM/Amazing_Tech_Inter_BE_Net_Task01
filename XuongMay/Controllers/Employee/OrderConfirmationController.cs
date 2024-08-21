using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers.Employee
{
    [Authorize(Roles = "admin,employeeconfirm")]
    [ApiController]
    [Route("api/orders/confirm")]
    public class OrderConfirmationController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderConfirmationController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut]
        public async Task<IActionResult> ConfirmOrder([FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.ConfirmOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã xác nhận đơn hàng." });
        }
    }
}
