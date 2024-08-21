using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Mappers;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.IServices;

namespace XuongMay.Services.CServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMapper _orderMapper;

        public OrderService(IOrderRepository orderRepository, IOrderMapper orderMapper)
        {
            _orderRepository = orderRepository;
            _orderMapper = orderMapper;
        }

        // Lấy danh sách tất cả đơn hàng.
        public async Task<List<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(order => _orderMapper.MapToResponse(order)).ToList();
        }

        // Tạo một đơn hàng mới.
        public async Task CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new Order
            {
                IdOrder = Guid.NewGuid(),
                Status = 0, // Đang xử lý
                Total = request.Total,
                CreateAt = DateTime.UtcNow,
                IdUser = request.IdUser
            };

            await _orderRepository.AddAsync(order);
        }

        // Xác nhận một đơn hàng.
        public async Task ConfirmOrderAsync(UpdateOrderStatusRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(request.IdOrder);
            if (order == null)
            {
                throw new Exception("Đơn hàng không tồn tại.");
            }

            if (order.Status != 0) // Kiểm tra trạng thái đơn hàng
            {
                throw new Exception("Đơn hàng không thể xác nhận vì trạng thái hiện tại không hợp lệ.");
            }

            order.Status = 1; // Đã xác nhận
            await _orderRepository.UpdateAsync(order);
        }

        // Hủy một đơn hàng.
        public async Task CancelOrderAsync(UpdateOrderStatusRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(request.IdOrder);
            if (order == null)
            {
                throw new Exception("Đơn hàng không tồn tại.");
            }

            if (order.Status != 0) // Kiểm tra trạng thái đơn hàng
            {
                throw new Exception("Đơn hàng không thể hủy vì trạng thái hiện tại không hợp lệ.");
            }

            order.Status = 2; // Đã hủy
            await _orderRepository.UpdateAsync(order);
        }
    }
}