using System.Runtime.CompilerServices;
using Authentication.BusinessLogic.Exceptions.AlreadyExistsException;
using Authentication.BusinessLogic.Exceptions.BadRequestException;
using Authentication.BusinessLogic.Exceptions.NotFoundException;
using Authentication.BusinessLogic.Exceptions;
using Authentication.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;

namespace Authentication.API.Middlewares
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
            ILoggerService loggerService)
        {
            app.UseExceptionHandler(apiError =>
            {
                apiError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            AlreadyExistsException => StatusCodes.Status409Conflict,
                            _ => StatusCodes.Status500InternalServerError
                        };
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
