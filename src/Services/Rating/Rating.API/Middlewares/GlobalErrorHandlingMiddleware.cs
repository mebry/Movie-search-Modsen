using Rating.BusinessLogic.Exceptions;
using System.Net;
using System.Text.Json;

namespace AspWebApi.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();

            HttpStatusCode status = DetermineStatus(exceptionType.Name);
            string message = exception.Message;
            string? stackTrace = exception.StackTrace;

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }

        private static HttpStatusCode DetermineStatus(string exceptionName) => exceptionName switch
        {
            nameof(BadRequestException) => HttpStatusCode.BadRequest,
            nameof(NotFoundException) => HttpStatusCode.NotFound,
            nameof(AlreadyExistException) => HttpStatusCode.Created,
            nameof(NotImplementedException) => HttpStatusCode.NotImplemented,
            nameof(UnauthorizedAccessException) => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError,
        };
    }
}