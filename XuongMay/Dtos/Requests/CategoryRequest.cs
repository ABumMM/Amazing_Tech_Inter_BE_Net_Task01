namespace XuongMay.Dtos.Requests
{
    public class CategoryRequest
    {
        public string? Slug { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; internal set; }
    }
}
