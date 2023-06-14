using Authentication.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using DataAccess.Extensions;
using NLog;
using Authentication.BusinessLogic.Extensions;
using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.ConfigureAPI();
builder.Services.ConfigureBusinessLogic();



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

if(app.Environment.IsProduction())
    app.UseHsts();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API v1");
});
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();
app.MapControllers();

app.Run();
