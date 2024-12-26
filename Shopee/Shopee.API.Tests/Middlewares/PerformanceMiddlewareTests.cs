using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Shopee.API.Middlewares;
using System.Diagnostics;

namespace Shopee.API.Tests.Middlewares
{
    public class PerformanceMiddlewareTests
    {
        private readonly Mock<ILogger<ExceptionHandlerMiddleware>> _mockLogger;
        private readonly Mock<RequestDelegate> _mockNext;
        private readonly PerformanceMiddleware _middleware;

        public PerformanceMiddlewareTests()
        {
            _mockLogger = new Mock<ILogger<ExceptionHandlerMiddleware>>();
            _mockNext = new Mock<RequestDelegate>();
            _middleware = new PerformanceMiddleware(_mockLogger.Object, _mockNext.Object);
        }

        private HttpContext CreateHttpContext()
        {
            var context = new DefaultHttpContext();
            context.Request.Method = "GET";
            context.Request.Path = "/test";
            context.Response.Body = new MemoryStream();
            return context;
        }

        [Fact]
        public async Task Invoke_ExecutesNextDelegate()
        {
            // Arrange
            var context = CreateHttpContext();
            _mockNext.Setup(x => x.Invoke(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);

            // Act
            await _middleware.Invoke(context);

            // Assert
            _mockNext.Verify(x => x.Invoke(It.IsAny<HttpContext>()), Times.Once());
        }

        [Fact]
        public async Task Invoke_LogsWarning_WhenRequestIsSlow()
        {
            // Arrange
            var context = CreateHttpContext();
            var stopwatch = new Stopwatch();
            _mockNext.Setup(x => x.Invoke(It.IsAny<HttpContext>()))
                .Callback(() => {
                    stopwatch.Start();
                    Task.Delay(600).Wait();  // Force a synchronous wait to ensure delay
                    stopwatch.Stop();
                })
                .Returns(Task.CompletedTask);

            // Act
            await _middleware.Invoke(context);

            // Assert
            // Check that the method logs a warning when the elapsed time is greater than 500ms
            _mockLogger.Verify(x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Request GET /test") && v.ToString().Contains("ms") && stopwatch.ElapsedMilliseconds >= 500),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        [Fact]
        public async Task Invoke_DoesNotLog_WhenRequestIsFast()
        {
            // Arrange
            var context = CreateHttpContext();
            _mockNext.Setup(x => x.Invoke(It.IsAny<HttpContext>()))
                .Callback(async () => await Task.Delay(100)) // Simulate quick processing
                .Returns(Task.CompletedTask);

            // Act
            await _middleware.Invoke(context);

            // Assert
            _mockLogger.Verify(x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("ms")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Never);
        }
    }
}
