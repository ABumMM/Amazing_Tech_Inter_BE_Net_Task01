namespace XuongMay.Dtos.Responses
{
    public class CategoryResponse
    {
        public Guid IdCategory { get; set; }
        public string? Slug { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
    }
}
