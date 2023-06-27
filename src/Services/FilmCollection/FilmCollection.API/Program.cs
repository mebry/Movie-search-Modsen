using FilmCollection.API.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;
using FilmCollection.BusinessLogic.Extensions;
using FilmCollection.DataAccess.Extensions;
using FilmCollection.API.Extensions;
using Shared.Extensions;
using Reporting.DataAccess.Extensions;
using FilmCollection.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.ConfigureBusinessLogic();
builder.Services.ConfigureAPI(builder.Configuration);

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmCollection API v1");
});
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.MapControllers();

app.ApplyMigrations<FilmCollectionContext>();

app.Run();
