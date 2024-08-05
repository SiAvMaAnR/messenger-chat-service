using MessengerX.Domain.Common;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.WebApi.Common;
using StackExchange.Redis;

namespace MessengerX.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddSingletonDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        string connection = AppEnvironment.GetRedisConnectionString(config);

        serviceCollection.AddSingleton<IAppSettings, AppSettings>();
        serviceCollection.AddSingleton<IConnectionMultiplexer>(
            ConnectionMultiplexer.Connect(connection)
        );

        return serviceCollection;
    }
}
