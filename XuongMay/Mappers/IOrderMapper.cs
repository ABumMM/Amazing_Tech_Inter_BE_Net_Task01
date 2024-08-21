using XuongMay.Dtos.Responses;
using XuongMay.Entity;

namespace XuongMay.Mappers
{
    public interface IOrderMapper
    {
        // ánh xạ đối tượng order qua phương thưc MapToResponse   (truyền...)
        OrderResponse MapToResponse(Order order);
    }
}
