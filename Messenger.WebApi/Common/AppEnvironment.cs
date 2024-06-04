namespace MessengerX.WebApi.Common;

public static class AppEnvironment
{
    internal const string Production = "Production";
    internal const string Development = "Development";
    private const string DefaultDBHost = "localhost";
    private const string DefaultDBPort = "1433";
    private const string DefaultRedisHost = "localhost";
    private const string DefaultRedisPort = "6379";

    public static string GetDBConnectionString(IConfiguration config)
    {
        string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? DefaultDBHost;
        string dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? DefaultDBPort;

        string? connectionString = config.GetConnectionString("DBConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (DB)");

        return connectionString.Replace("$DB_HOST", dbHost).Replace("$DB_PORT", dbPort);
    }

    public static string GetRedisConnectionString(IConfiguration config)
    {
        string redisHost = Environment.GetEnvironmentVariable("REDIS_HOST") ?? DefaultRedisHost;
        string redisPort = Environment.GetEnvironmentVariable("REDIS_PORT") ?? DefaultRedisPort;

        string? connectionString = config.GetConnectionString("RedisConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (Redis)");

        return connectionString.Replace("$REDIS_HOST", redisHost).Replace("$REDIS_PORT", redisPort);
    }
}
