using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Persistence.DBContext;
using MessengerX.WebApi.Configurations.Common;
using MessengerX.WebApi.Configurations.Other;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace MessengerX.WebApi.Configurations.WebService;

public static partial class WebServiceExtension
{
    public static IServiceCollection AddCommonDependencies(
        this IServiceCollection serviceCollection,
        ConfigurationManager config
    )
    {
        string connection = config?.GetConnectionString("DefaultConnection") ?? "";
        serviceCollection.AddDbContext<EFContext>(options => options.UseSqlServer(connection));
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddLogging();
        serviceCollection.AddCors(options => options.CorsConfig());
        serviceCollection.AddAuthorization(options => options.PolicyConfig());
        serviceCollection.AddSwaggerGen(options => options.Config());
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.Config(config));
        serviceCollection.AddDataProtection();
        serviceCollection.AddSignalR();

        return serviceCollection;
    }
}
