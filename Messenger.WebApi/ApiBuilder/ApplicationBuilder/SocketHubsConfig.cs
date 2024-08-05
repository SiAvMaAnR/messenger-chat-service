using Messenger.WebApi.Hubs;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.WebApi.ApiBuilder.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        webApplication.MapHub<ChatHub>(HubPath.Chat);
        webApplication.MapHub<StateHub>(HubPath.State);
    }
}
