using MessengerX.Domain.Shared.Environment;

namespace MessengerX.WebApi.ApiConfigurations.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddConfigurationDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        Dictionary<string, IConfigurationSection> configurations =
            new()
            {
                { "commonSettings", config.GetSection(CommonSettings.Path) },
                { "authSettings", config.GetSection(AuthSettings.Path) },
                { "clientSettings", config.GetSection(ClientSettings.Path) },
                { "pathSettings", config.GetSection(PathSettings.Path) },
                { "smtpSettings", config.GetSection(SmtpSettings.Path) },
            };

        serviceCollection.Configure<CommonSettings>(configurations["commonSettings"]);
        serviceCollection.Configure<AuthSettings>(configurations["authSettings"]);
        serviceCollection.Configure<ClientSettings>(configurations["clientSettings"]);
        serviceCollection.Configure<PathSettings>(configurations["pathSettings"]);
        serviceCollection.Configure<SmtpSettings>(configurations["smtpSettings"]);

        return serviceCollection;
    }
}
