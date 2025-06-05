using Presentation.VMs.Helpers;
using System.Net;
using System.Text.Json;

namespace Presentation.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (ApiBaseException ex)
            {
                _logger.LogError(ex, "An error occurred");
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = "application/json";

                ApiErrorResponse response = ApiErrorResponse.FromException(ex);

                string jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                ApiErrorResponse genericResponse = new ApiErrorResponse
                {
                    Timestamp = DateTime.UtcNow,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = "An unexpected error occurred."
                };

                string jsonResponse = JsonSerializer.Serialize(genericResponse);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
