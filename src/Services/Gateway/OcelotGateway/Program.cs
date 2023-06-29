using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile(builder.Configuration["Ocelot:OcelotFile"], optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseRouting();
app.UseSwaggerForOcelotUI(options =>
    options.PathToSwaggerGenerator = "/swagger/docs");
await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();



app.Run();
