namespace MessengerX.WebApi.Configurations.WebApp;

public static partial class WebApplicationExtension
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
