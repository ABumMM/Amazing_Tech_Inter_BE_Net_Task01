namespace XuongMay.Dtos.Requests
{
    public class ProductRequest
    {
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
