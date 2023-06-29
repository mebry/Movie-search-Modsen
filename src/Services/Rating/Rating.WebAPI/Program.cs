using Hangfire;
using Microsoft.AspNetCore.HttpOverrides;
using Rating.BusinessLogic.Extensions;
using Rating.DataAccess.Contexts;
using Rating.WebAPI.Extensions;
using Shared.Extensions;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBusinessLogicService();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHagfire(builder.Configuration);
builder.Services.ConfigureMassTransit(builder.Configuration);
builder.Services.ConfigureSwagger(builder.Configuration);
builder.Services.ConfigureCors();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if(!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Rating API");
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

var forwardedHeaders = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
};

app.UseForwardedHeaders(forwardedHeaders);

app.MapControllers();

app.ApplyMigrations<ApplicationContext>();

app.UseHangfireDashboard();
app.MapHangfireDashboard();

app.UseHangfireRecurringJobs(builder.Configuration);

app.Run();
