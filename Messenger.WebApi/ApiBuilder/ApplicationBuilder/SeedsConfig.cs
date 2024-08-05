using Messenger.Persistence.DBContext;
using Messenger.Persistence.Seeds;

namespace Messenger.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void SeedsConfiguration(this WebApplication webApplication)
    {
        using IServiceScope scope = webApplication.Services.CreateScope();

        EFContext dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();
        ILogger<EFContext> logger = scope.ServiceProvider.GetRequiredService<ILogger<EFContext>>();

        SeedsInitiator.Apply(dbContext, logger);
    }
}
