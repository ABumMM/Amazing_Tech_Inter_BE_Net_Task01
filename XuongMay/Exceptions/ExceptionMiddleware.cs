using System.Net;
using System.Text.Json;
using XuongMay.Dtos.Responses;

namespace XuongMay.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Đã xảy ra một ngoại lệ chưa được xử lý.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // Lỗi 500

            var result = new ApiResponse
            {
                Success = false,
                Message = "Lỗi máy chủ nội bộ"
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var json = JsonSerializer.Serialize(result);
            return context.Response.WriteAsync(json);
        }
    }
}
