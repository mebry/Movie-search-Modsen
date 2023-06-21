using FilmCollection.BusinessLogic.Exceptions;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;
using Microsoft.AspNetCore.Diagnostics;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.API.Middlewares
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
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
                            SharedExceptions.NotFoundException => StatusCodes.Status404NotFound,
                            SharedExceptions.AlreadyExistsException => StatusCodes.Status409Conflict,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        app.Logger.LogError($"Something went wrong: {contextFeature.Error}");

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
