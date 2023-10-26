namespace MessengerX.WebApi.Configurations.WebApp;

public static partial class WebApplicationExtension
{
    public static void HubsConfiguration(this WebApplication webApplication)
    {
        // webApplication.MapHub<ChatHub>("/chat");
    }
}
