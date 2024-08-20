namespace XuongMay.Dtos.Requests
{
    public class OrderRequest
    {
        public Guid? IdOrder { get; set; } // Mã định danh của đơn hàng
        public int? Status { get; set; } // Trạng thái của đơn hàng (mặc định là 0)
        public decimal Total { get; set; } // Tổng giá trị của đơn hàng
        public Guid? IdUser { get; set; } // ID của người dùng thực hiện đơn hàng
    }
}
