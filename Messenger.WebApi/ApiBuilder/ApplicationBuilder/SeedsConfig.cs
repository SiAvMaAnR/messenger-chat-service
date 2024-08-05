using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Seeds;

namespace MessengerX.WebApi.ApiBuilder.ApplicationBuilder;

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
