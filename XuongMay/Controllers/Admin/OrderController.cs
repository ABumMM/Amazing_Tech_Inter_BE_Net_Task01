using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/admin/orders")]
    public class AdminOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // lấy tất cả đơn hàng
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(new { Success = true, Data = orders });
        }

        // tạo tất cả đơn hàng
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            await _orderService.CreateOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã tạo đơn hàng thành công." });
        }

        // xác nhận đơn hàng
        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmOrder([FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.ConfirmOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã xác nhận đơn hàng." });
        }

        // hủy đơn hàng
        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrder([FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.CancelOrderAsync(request);
            return Ok(new { Success = true, Message = "Đã hủy đơn hàng." });
        }
    }
}
