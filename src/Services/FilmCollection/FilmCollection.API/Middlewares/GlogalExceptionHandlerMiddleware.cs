using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;
using Microsoft.AspNetCore.Diagnostics;

namespace FilmCollection.API.Middlewares
{
    public static class GlogalExceptionHandlerMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
           ILogger logger)
        {
            app.UseExceptionHandler(apiError =>
            {
                apiError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            AlreadyExistsException => StatusCodes.Status409Conflict,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                }
                );
            });
        }
    }
}
