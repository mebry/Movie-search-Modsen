using AspWebApi.Middlewares;
using Hangfire;
using Rating.BusinessLogic.Extensions;
using Rating.BusinessLogic.Services.EventDecisionServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddBusinessLogicService(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(configuration => configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

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

RecurringJob.AddOrUpdate<IEventDecisionService>(
    "everyhour",
    x => x.DecisionToSendCountOfRatingShortChangEvent(),
    "0 0 * ? * * *");

RecurringJob.AddOrUpdate<IEventDecisionService>(
    "everymonth",
    x => x.DecisionToSendCountOfRatingLongChangEvent(),
    "0 0 0 ? * * *");

app.Run();
