using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XuongMay.Dtos.Responses;

namespace XuongMay.Helpers
{
    public class TokenHelper
    {
        private static TokenHelper _instance;
        public static TokenHelper Instance
        {
            get { return _instance ??= new TokenHelper(); }
            private set { _instance = value; }
        }

        public string CreateToken(string email, string role, IConfiguration config)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var secretKey = config["Jwt:Secret"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(tokenDescriptor);

            return "bearer " + tokenString; // Trả về mã thông báo có tiền tố "bearer" nếu cần
        }
    }
}
