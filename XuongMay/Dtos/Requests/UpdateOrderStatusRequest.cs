    using System.ComponentModel.DataAnnotations;

    namespace XuongMay.Dtos.Requests
    {
        public class UpdateOrderStatusRequest
        {
            [Required]
            public Guid IdOrder { get; set; }

            [Required]
            public int Status { get; set; }
        }
    }
