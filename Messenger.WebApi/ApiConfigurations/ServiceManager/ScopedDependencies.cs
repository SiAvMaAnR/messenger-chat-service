using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AuthService;
using MessengerX.Application.Services.ChannelService;
using MessengerX.Application.Services.ChatService;
using MessengerX.Application.Services.UserService;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Persistence.UnitOfWork;

namespace MessengerX.WebApi.ApiConfigurations.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddScopedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IAdminService, AdminService>();
        serviceCollection.AddScoped<IChannelService, ChannelService>();
        serviceCollection.AddScoped<IChatService, ChatService>();

        return serviceCollection;
    }
}
