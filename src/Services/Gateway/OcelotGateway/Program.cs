using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.ConfigureAuthentication();
var app = builder.Build();

await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
