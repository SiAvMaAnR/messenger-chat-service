namespace MessengerX.WebApi.ApiConfigurations.ApplicationBuilder;

public static partial class ApplicationBuilderExtension
{
    private const string Production = "Production";
    private const string Development = "Development";
    private const string Docker = "Docker";

    public static IApplicationBuilder AddEnvironmentConfiguration(
        this WebApplication webApplication
    )
    {
        return webApplication.Environment.EnvironmentName switch
        {
            Production => webApplication.ProductionConfiguration(),
            Development => webApplication.DevelopmentConfiguration(),
            Docker => webApplication.DockerConfiguration(),
            _ => throw new NotImplementedException(),
        };
    }

    internal static IApplicationBuilder DevelopmentConfiguration(this WebApplication webApplication)
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

        return webApplication;
    }

    internal static IApplicationBuilder ProductionConfiguration(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler(
            new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = true,
                ExceptionHandlingPath = "/Production"
            }
        );

        return webApplication;
    }

    internal static IApplicationBuilder DockerConfiguration(this WebApplication webApplication)
    {
        webApplication.UseExceptionHandler(
            new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = true,
                ExceptionHandlingPath = "/Docker"
            }
        );
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI();

        return webApplication;
    }
}
