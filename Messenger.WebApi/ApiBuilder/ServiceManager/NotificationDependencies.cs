using Messenger.Domain.Shared.Settings;
using Messenger.Notifications.Email;
using Messenger.Notifications.Email.Models;

namespace Messenger.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddNotificationDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        var smtpSettings = new SmtpSettings();

        configuration.GetSection(SmtpSettings.Path).Bind(smtpSettings);

        serviceCollection.AddSingleton<IEmailClient>(
            new EmailClient(
                new SmtpConfig()
                {
                    Email = smtpSettings.Email,
                    Password = smtpSettings.Password,
                    Host = smtpSettings.Host,
                    Port = smtpSettings.Port
                }
            )
        );

        return serviceCollection;
    }
}
