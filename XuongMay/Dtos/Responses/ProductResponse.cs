namespace XuongMay.Dtos.Responses
{
    public class ProductResponse
    {
        public Guid IdProduct { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Type { get; set; }
        public Guid? IdUser { get; set; }
        public Guid? IdCategory { get; set; }
    }
}
