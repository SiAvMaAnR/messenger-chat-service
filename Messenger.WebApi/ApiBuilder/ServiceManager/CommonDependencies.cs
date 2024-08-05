using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Persistence.DBContext;
using MessengerX.WebApi.ApiBuilder.Other;
using MessengerX.WebApi.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddCommonDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration config
    )
    {
        string? connection = AppEnvironment.GetDBConnectionString(config);

        serviceCollection.AddOptions();
        serviceCollection.AddDbContext<EFContext>(options => options.UseSqlServer(connection));
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddLogging();
        serviceCollection.AddCors(options => options.CorsConfig());
        serviceCollection.AddAuthorization(options => options.PolicyConfig());
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.Config(config));
        serviceCollection.AddSwaggerGen(options => options.Config());
        serviceCollection.AddDataProtection();
        serviceCollection.AddSignalR();
        serviceCollection.AddHttpClient();

        return serviceCollection;
    }
}
