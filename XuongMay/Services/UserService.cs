using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Repositories;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace XuongMay.Services
{
    public interface IUserService
    {
        Task<UserResponse?> AuthenticateAsync(LoginRequest request);
        Task<RegisterResponse?> RegisterAsync(RegisterRequest request);
    }

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
                throw new InvalidOperationException("JWT Secret is not configured.");
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
                Id = user.IdUser.ToString(),
                Email = user.Email,
                Token = tokenString
            };
        }

        public async Task<RegisterResponse?> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            var role = await _roleRepository.GetRoleByNameAsync(request.Role);
            if (role == null)
            {
                throw new InvalidOperationException("Role not found.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                IdUser = Guid.NewGuid(), // Thêm IdUser
                Email = request.Email,
                Password = hashedPassword,
                IdRole = role.IdRole,
                CreateAt = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(user);

            return new RegisterResponse
            {
                Id = user.IdUser.ToString(),
                Email = user.Email,
                Role = role.Name
            };
        }
    }
}
