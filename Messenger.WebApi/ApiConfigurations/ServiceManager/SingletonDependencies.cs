using MessengerX.Infrastructure.AppSettings;

namespace MessengerX.WebApi.ApiConfigurations.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddSingletonDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddSingleton<IAppSettings, AppSettings>();

        return serviceCollection;
    }
}
