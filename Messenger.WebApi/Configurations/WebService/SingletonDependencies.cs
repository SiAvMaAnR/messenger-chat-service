namespace MessengerX.WebApi.Configurations.WebService;

public static partial class WebServiceExtension
{
    public static IServiceCollection AddSingletonDependencies(
        this IServiceCollection serviceCollection
    )
    {
        return serviceCollection;
    }
}
