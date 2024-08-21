using XuongMay.Dtos.Responses;
using XuongMay.Entity;

namespace XuongMay.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        // MapToResponse nhận vào một đối tượng Order và trả về một đối tượng OrderResponse
        public OrderResponse MapToResponse(Order order)
        {
            if (order == null)
            {
                return null;
            }

            return new OrderResponse
            {
                IdOrder = order.IdOrder,
                Status = (int)order.Status,
                Total = order.Total,
                CreateAt = order.CreateAt,
                IdUser = order.IdUser
            };
        }
    }
}
