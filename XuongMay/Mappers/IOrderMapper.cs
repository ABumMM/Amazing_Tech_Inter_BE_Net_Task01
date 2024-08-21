using XuongMay.Dtos.Responses;
using XuongMay.Entity;

namespace XuongMay.Mappers
{
    public interface IOrderMapper
    {
        OrderResponse MapToResponse(Order order);
    }
}
