namespace MessengerX.WebApi.Common;

public static class AppEnvironment
{
    internal const string Production = "Production";
    internal const string Development = "Development";

    public static string? GetConnectionString(IConfiguration config)
    {
        string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";

        return config.GetConnectionString("DefaultConnection")?.Replace("$DB_HOST", dbHost);
    }
}
