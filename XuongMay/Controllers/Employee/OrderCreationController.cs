using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers.Employee
{
    [Authorize(Roles = "admin,employee")]
    [ApiController]
    [Route("api/orders/employee/create")]
    public class OrderCreationController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderCreationController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            await _orderService.CreateOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã tạo đơn hàng thành công." });
        }
    }
}
