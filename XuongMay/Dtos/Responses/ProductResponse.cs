namespace XuongMay.Dtos.Responses
{
    public class ProductResponse
    {
        public Guid IdProduct { get; set; }
        public string? Slug { get; set; }
        public string Name { get; set; } = null!;
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
