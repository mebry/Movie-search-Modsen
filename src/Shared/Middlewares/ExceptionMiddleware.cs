using Shared.Exceptions;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Shared.Middlewares
{
    /// <summary>
    /// Middleware for handling exceptions that occur during the processing of HTTP requests.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles the exception and writes the response to the context.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status = GetStatusCode(exception);
            string message = exception.Message;
            string? stackTrace = exception.StackTrace;

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            if (status == HttpStatusCode.InternalServerError)
            {
                _logger.LogError(exception, message);
            }

            return context.Response.WriteAsync(exceptionResult);
        }

        /// <summary>
        /// Gets the HTTP status code based on the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>The corresponding HTTP status code.</returns>
        private static HttpStatusCode GetStatusCode(Exception exception) => exception switch
        {
            ValidationProblemException => HttpStatusCode.BadRequest,
            BadRequestException => HttpStatusCode.BadRequest,
            NotFoundException => HttpStatusCode.NotFound,
            AlreadyExistsException => HttpStatusCode.Conflict,
            NotImplementedException => HttpStatusCode.NotImplemented,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError,
        };
    }
}
