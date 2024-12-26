using System.Diagnostics;

namespace Shopee.API.Middlewares
{
    public class PerformanceMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public PerformanceMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            const int performanceTimeLog = 500;

            var sw = new Stopwatch();

            sw.Start();

            await _next(context);

            sw.Stop();

            if (performanceTimeLog < sw.ElapsedMilliseconds)
                _logger.LogWarning("Request {method} {path} it took about {elapsed} ms",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    sw.ElapsedMilliseconds);
        }
    }
}

