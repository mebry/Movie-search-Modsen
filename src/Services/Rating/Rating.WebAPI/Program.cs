using Hangfire;
using Rating.API.Extensions;
using Rating.BusinessLogic.Extensions;
using Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBusinessLogicService(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHagfire(builder.Configuration);

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

app.UseHangfireRecurringJobs();

app.Run();
