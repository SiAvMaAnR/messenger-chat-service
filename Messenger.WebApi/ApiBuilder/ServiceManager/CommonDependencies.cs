using Messenger.Infrastructure.AuthOptions;
using Messenger.Persistence.DBContext;
using Messenger.WebApi.ApiBuilder.Other;
using Messenger.WebApi.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.EntityFrameworkCore;

namespace Messenger.WebApi.ApiBuilder.ServiceManager;

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
        serviceCollection
            .AddDataProtection()
            .UseCryptographicAlgorithms(
                new AuthenticatedEncryptorConfiguration
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                }
            );
        ;
        serviceCollection.AddSignalR();
        serviceCollection.AddHttpClient();

        return serviceCollection;
    }
}
