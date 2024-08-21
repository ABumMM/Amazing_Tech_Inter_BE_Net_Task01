using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay.Repositories.CRepository;
using XuongMay.Services.IServices;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Services.CServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        // xử lý quá trình xác thực người dùng và tạo JWT token
        public async Task<UserResponse?> AuthenticateAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = jwtSettings.GetValue<string>("Secret");
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT Secret chưa được cấu hình.");
            }

            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdUser.ToString()),
                    new Claim(ClaimTypes.Role, user.IdRoleNavigation?.Name ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserResponse
            {
                Id = user.IdUser.ToString(), // Ép kiểu
                Email = user.Email,
                Token = tokenString
            };
        }

        // đăng ký người dùng mới, mã hóa mật khẩu, ...
        public async Task<RegisterResponse?> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Người dùng đã tồn tại.");
            }

            var role = await _roleRepository.GetRoleByNameAsync(request.Role);
            if (role == null)
            {
                throw new InvalidOperationException("Quyền không tồn tại.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                IdUser = Guid.NewGuid(), // Thêm IdUser
                Email = request.Email,
                Password = hashedPassword, // Mã hóa mật khẩu
                IdRole = role.IdRole,
                CreateAt = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(user);

            return new RegisterResponse
            {
                Id = user.IdUser.ToString(), // Ép kiểu
                Email = user.Email,
                Role = role.Name
            };
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => new UserResponse
            {
                Id = user.IdUser.ToString(),
                Email = user.Email,
                Password = user.Password,
            });
        }

        public async Task<UserResponse?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserResponse
            {
                Id = user.IdUser.ToString(),
                Email = user.Email,
                Password = user.Password,
            };
        }

        public async Task<UserResponse?> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException("Người dùng Không tồn tại."); 
            }

            // Cập nhật thông tin người dùng
            user.Email = request.Email ?? user.Email;
            if (!string.IsNullOrEmpty(request.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            }
            if (request.Role != null)
            {
                var role = await _roleRepository.GetRoleByNameAsync(request.Role);
                if (role == null)
                {
                    throw new InvalidOperationException("Quyền không tồn tại.");
                }
                user.IdRole = role.IdRole;
            }

            await _userRepository.UpdateUserAsync(user);

            return new UserResponse
            {
                Id = user.IdUser.ToString(),
                Email = user.Email,
                Password = user.Password
            };
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteUserAsync(user);
            return true;
        }
    }
}
