using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Services.CServices;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // đăng nhập
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.AuthenticateAsync(request);

            if (response == null)
            {
                return Unauthorized(new ApiResponse
                {
                    Success = false,
                    Message = "Email hoặc mật khẩu không hợp lệ."
                });
            }

            return Ok(response);
        }

        // đăng ký
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _userService.RegisterAsync(request);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // lấy tất cả tài khoản với quyền admin
        [HttpGet("AllUsers")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // lấy tài khoản theo id với quyền admin
        [HttpGet("user/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng."
                });
            }

            return Ok(user);
        }

        // sửa tài khoản theo id với quyền admin
        [HttpPut("user/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
        {
            var user = await _userService.UpdateUserAsync(id, request);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng."
                });
            }

            return Ok(user);
        }

        // xóa tài khoản theo id với quyền admin
        [HttpDelete("user/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng."
                });
            }

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Xóa người dùng thành công."
            });
        }
    }
}
