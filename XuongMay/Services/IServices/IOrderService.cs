using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task CreateOrderAsync(CreateOrderRequest request);
        Task ConfirmOrderAsync(UpdateOrderStatusRequest request);
        Task CancelOrderAsync(UpdateOrderStatusRequest request);
    }
}
