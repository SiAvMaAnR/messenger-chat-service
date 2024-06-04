namespace MessengerX.WebApi.Common;

public static class AppEnvironment
{
    internal const string Production = "Production";
    internal const string Development = "Development";

    public static string GetDBConnectionString(IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("DBConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (DB)");

        return connectionString;
    }

    public static string GetRedisConnectionString(IConfiguration config)
    {
        string? connectionString = config.GetConnectionString("RedisConnection");

        if (connectionString == null)
            throw new Exception("Connection string is not correct (Redis)");

        return connectionString;
    }
}
