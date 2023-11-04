using MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;
using MessengerX.WebApi.ApiConfigurations.ServiceManager;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddConfigurationDependencies(config);
builder.Services.AddCommonDependencies(config);
builder.Services.AddNotificationDependencies(config);
builder.Services.AddTransientDependencies();
builder.Services.AddScopedDependencies();
builder.Services.AddSingletonDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.DevelopmentConfiguration();
else
    app.ProductionConfiguration();

app.CommonConfiguration();
app.HubsConfiguration();
app.Run();
