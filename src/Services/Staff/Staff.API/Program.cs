using Staff.API.Extensions;
using Staff.BusinessLogic.Extensions;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogicService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<StaffsDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMassTransit(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ApplyMigrations();

app.Run();
