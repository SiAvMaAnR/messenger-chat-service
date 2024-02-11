using Messenger.SignalR.Hubs;

namespace MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        webApplication.MapHub<ChatHub>("/chat");
    }
}
