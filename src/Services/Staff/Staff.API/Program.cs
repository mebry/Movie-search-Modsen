using Microsoft.AspNetCore.HttpOverrides;
using Shared.Extensions;
using Shared.Middlewares;
using Staff.API.Extensions;
using Staff.BusinessLogic.Extensions;
using Staff.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogicService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<StaffsDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureMassTransit(builder.Configuration);
builder.Services.ConfigureSwagger(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Staff API");
    });
}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");


app.MapControllers();

app.ApplyMigrations<StaffsDbContext>();

app.Run();
