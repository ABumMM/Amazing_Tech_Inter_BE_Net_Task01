namespace XuongMay.Dtos.Responses
{
    public class OrderResponse
    {
        public Guid IdOrder { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid? IdUser { get; set; }
    }
}
