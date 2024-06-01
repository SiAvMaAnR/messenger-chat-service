namespace MessengerX.WebApi.Common;

public static class AppEnvironment
{
    internal const string Production = "Production";
    internal const string Development = "Development";

    public static string GetDBConnectionString(IConfiguration config)
    {
        string? dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        string? dbPort = Environment.GetEnvironmentVariable("DB_PORT");

        string? connectionString = config.GetConnectionString("DBConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (DB)");

        return connectionString.Replace("$DB_HOST", dbHost).Replace("$DB_PORT", dbPort);
    }

    public static string GetRedisConnectionString(IConfiguration config)
    {
        string? redisHost = Environment.GetEnvironmentVariable("REDIS_HOST");
        string? redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");

        string? connectionString = config.GetConnectionString("DBConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (Redis)");

        return connectionString.Replace("$REDIS_HOST", redisHost).Replace("$REDIS_PORT", redisPort);
    }
}
