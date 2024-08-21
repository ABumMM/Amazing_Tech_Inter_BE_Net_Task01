using System.ComponentModel.DataAnnotations;

namespace XuongMay.Dtos.Requests
{
    public class CreateOrderRequest
    {
        [Required]
        public decimal Total { get; set; }

        [Required]
        public Guid IdUser { get; set; }
    }
}
