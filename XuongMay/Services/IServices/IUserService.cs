using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IUserService
    {
        Task<UserResponse?> AuthenticateAsync(LoginRequest request);
        Task<RegisterResponse?> RegisterAsync(RegisterRequest request);


        Task<IEnumerable<UserResponse>> GetAllUsersAsync();  // Lấy tất cả người dùng
        Task<UserResponse?> GetUserByIdAsync(Guid id);       // Lấy người dùng theo ID
        Task<bool> DeleteUserAsync(Guid id);                 // xóa người dùng theo id

    }
}
