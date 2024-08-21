using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XuongMay.Exceptions
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            // Log request information
            _logger.LogInformation("Handling request: {method} {url}", context.Request.Method, context.Request.Path);

            await _next(context);

            // Log response information
            watch.Stop();
            var responseTime = watch.ElapsedMilliseconds;

            _logger.LogInformation("Finished handling request. Response status code: {statusCode}, Duration: {responseTime}ms",
                                    context.Response.StatusCode, responseTime);
        }
    }
}
