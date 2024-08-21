using System.ComponentModel.DataAnnotations;

namespace XuongMay.Dtos.Requests
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Detail { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Type { get; set; }

        public Guid? IdUser { get; set; }

        public Guid? IdCategory { get; set; }
    }
}
