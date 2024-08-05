using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.UserService;
using MessengerX.Application.Services.AuthService;
using MessengerX.Application.Services.ChannelService;
using MessengerX.Application.Services.ChatService;
using MessengerX.Domain.Common;
using MessengerX.Domain.Services;
using MessengerX.Infrastructure.RabbitMQ;
using MessengerX.Persistence.UnitOfWork;

namespace MessengerX.WebApi.ApiBuilder.ServiceManager;

public static partial class ServiceManagerExtension
{
    public static IServiceCollection AddScopedDependencies(
        this IServiceCollection serviceCollection
    )
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        serviceCollection.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();

        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IChannelService, ChannelService>();
        serviceCollection.AddScoped<IChatService, ChatService>();

        serviceCollection.AddScoped<UserBS>();
        serviceCollection.AddScoped<AccountBS>();
        serviceCollection.AddScoped<AuthBS>();
        serviceCollection.AddScoped<AdminBS>();
        serviceCollection.AddScoped<ChannelBS>();
        serviceCollection.AddScoped<ChatBS>();

        return serviceCollection;
    }
}
