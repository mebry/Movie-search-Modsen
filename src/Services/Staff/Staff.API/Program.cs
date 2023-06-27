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
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMassTransit(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ApplyMigrations<StaffsDbContext>();

app.Run();
