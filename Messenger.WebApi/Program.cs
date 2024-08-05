using MessengerX.WebApi.ApiBuilder.ApplicationBuilder;
using MessengerX.WebApi.ApiBuilder.LoggingBuilder;
using MessengerX.WebApi.ApiBuilder.ServiceManager;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddConfigurationDependencies(config);
builder.Services.AddCommonDependencies(config);
builder.Services.AddNotificationDependencies(config);
builder.Services.AddTransientDependencies();
builder.Services.AddScopedDependencies();
builder.Services.AddSingletonDependencies(config);

builder.Logging.AddCommonConfiguration(config);

WebApplication application = builder.Build();

application.AddEnvironmentConfiguration();
application.CommonConfiguration();
application.HubsConfiguration();
application.SeedsConfiguration();

application.Run();
