using Authentication.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using DataAccess.Extensions;
using NLog;
using Authentication.BusinessLogic.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureAPI();
builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.ConfigureBusinessLogic();


var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

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
