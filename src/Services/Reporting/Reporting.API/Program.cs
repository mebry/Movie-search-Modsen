using Reporting.API.Extensions;
using Reporting.BusinessLogic.Extensions;
using Reporting.DataAccess.Contexts;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBusinessLogicService();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMassTransit(builder.Configuration);
builder.Services.ConfigureSwagger(builder.Configuration);
builder.Services.ConfigureCors();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "Reporting API");
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.ApplyForwardedHeaders();

app.MapControllers();

app.ApplyMigrations<ReportingContext>();

app.Run();
