using Microsoft.AspNetCore.HttpOverrides;
using Reviews.API.Extensions;
using Reviews.BusinessLogic.Extensions;
using Reviews.DataAccess.Contexts;
using Shared.Extensions;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogicService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<ReviewsDbContext>();
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
        s.SwaggerEndpoint("/swagger/swagger.json", "Review API");
    });
}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.ApplyMigrations<ReviewsDbContext>();

app.Run();
