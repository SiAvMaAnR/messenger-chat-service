namespace MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
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
