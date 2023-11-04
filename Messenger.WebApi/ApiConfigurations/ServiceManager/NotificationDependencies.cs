using MessengerX.Domain.Shared.Environment;
using MessengerX.Notifications;
using MessengerX.Notifications.Email.Handlers;
using MessengerX.Notifications.Email.Models;

namespace MessengerX.WebApi.ApiConfigurations.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddNotificationDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        SmtpSettings smtpSettings = new();

        configuration.GetSection(SmtpSettings.Path).Bind(smtpSettings);

        serviceCollection.AddSingleton(
            new EmailClient(
                new MessageHandler(
                    new Smtp()
                    {
                        Email = smtpSettings.Email,
                        Password = smtpSettings.Password,
                        Host = smtpSettings.Host,
                        Port = smtpSettings.Port
                    }
                )
            )
        );

        return serviceCollection;
    }
}