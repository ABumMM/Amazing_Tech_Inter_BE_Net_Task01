namespace XuongMay.Dtos.Requests
{
    public class UserRequest
    {
        public string Email { get; set; } = string.Empty;

        public string? Name { get; set; }

        public string Password { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public Guid? IdRole { get; set; }
    }
}
