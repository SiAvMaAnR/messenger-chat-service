namespace MessengerX.WebApi.Configurations.WebService;

public static partial class WebServiceExtension
{
    public static IServiceCollection AddTransientDependencies(
        this IServiceCollection serviceCollection
    )
    {
        return serviceCollection;
    }
}
