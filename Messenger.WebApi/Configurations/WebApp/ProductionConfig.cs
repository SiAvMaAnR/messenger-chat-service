namespace MessengerX.WebApi.Configurations.WebApp;

public static partial class WebApplicationExtension
{
    public static void ProductionConfiguration(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler(
            new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = true,
                ExceptionHandlingPath = "/Production"
            }
        );
    }
}
