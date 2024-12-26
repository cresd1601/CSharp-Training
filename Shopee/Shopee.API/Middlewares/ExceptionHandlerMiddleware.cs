using Shopee.Application.DTOs;
using Shopee.Application.Exceptions;
using System.Net;

namespace Shopee.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (RegistrationFailedException ex)
            {
                LogError(ex, "Registration failed.");
                await RespondWithApiError(httpContext, HttpStatusCode.BadRequest, new[] { ex.Message });
            }
            catch (ResourceNotFoundException ex)
            {
                LogWarning(ex, "Resource not found.");
                await RespondWithApiError(httpContext, HttpStatusCode.NotFound, new[] { ex.Message });
            }
            catch (EmptyCartException ex)
            {
                // Handling the EmptyCartException specifically
                LogWarning(ex, "Attempt to create an order with an empty cart.");
                await RespondWithApiError(httpContext, HttpStatusCode.BadRequest, new[] { ex.Message });
            }
            catch (Exception exception)
            {
                LogError(exception, "An unexpected error has occurred.");
                await RespondWithApiError(httpContext, HttpStatusCode.InternalServerError, new[] { "An unexpected error has occurred. Please try again later." });
            }
        }

        private void LogWarning(Exception ex, string message)
        {
            _logger.LogWarning(ex, message);
        }

        private void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        private static async Task RespondWithApiError(HttpContext httpContext, HttpStatusCode statusCode, IEnumerable<string> messages)
        {
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";

            var apiResponse = ApiResponseDto<object>.Failure(messages, "BadRequest");
            await httpContext.Response.WriteAsJsonAsync(apiResponse);
        }
    }
}