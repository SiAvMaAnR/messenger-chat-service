using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.UserService;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Persistence.UnitOfWork;

namespace MessengerX.WebApi.Configurations.WebService;

public static partial class WebServiceExtension
{
    public static IServiceCollection AddScopedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();

        return serviceCollection;
    }
}
