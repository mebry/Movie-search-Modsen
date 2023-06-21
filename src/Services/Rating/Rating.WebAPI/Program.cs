using Hangfire;
using Rating.BusinessLogic.Extensions;
using Rating.DataAccess.Extensions;
using Rating.WebAPI.Extensions;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBusinessLogicService();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHagfire(builder.Configuration);
builder.Services.ConfigureMassTransit(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.MapHangfireDashboard();

app.ApplyMigrations();

app.UseHangfireRecurringJobs(builder.Configuration);

app.Run();
