using MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;
using MessengerX.WebApi.ApiConfigurations.LoggingBuilder;
using MessengerX.WebApi.ApiConfigurations.ServiceManager;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddConfigurationDependencies(config);
builder.Services.AddCommonDependencies(config);
builder.Services.AddNotificationDependencies(config);
builder.Services.AddTransientDependencies();
builder.Services.AddScopedDependencies();
builder.Services.AddSingletonDependencies();

builder.Logging.AddCommonConfiguration(config);

WebApplication application = builder.Build();

application.AddEnvironmentConfiguration();
application.CommonConfiguration();
application.HubsConfiguration();
application.Run();
