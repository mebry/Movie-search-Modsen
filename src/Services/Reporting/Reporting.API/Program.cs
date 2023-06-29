using Microsoft.AspNetCore.HttpOverrides;
using Reporting.API.Extensions;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
        s.SwaggerEndpoint("/swagger/swagger.json", "Rating API");
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

app.Run();
