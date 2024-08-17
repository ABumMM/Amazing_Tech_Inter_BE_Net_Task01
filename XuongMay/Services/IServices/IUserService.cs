using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IUserService
    {
        Task<UserResponse?> AuthenticateAsync(LoginRequest request);
        Task<RegisterResponse?> RegisterAsync(RegisterRequest request);
    }
}
