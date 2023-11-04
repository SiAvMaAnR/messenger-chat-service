namespace MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    public static void DevelopmentConfiguration(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler(
            new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = true,
                ExceptionHandlingPath = "/Development"
            }
        );
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI();
    }
}
