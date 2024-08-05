using Messenger.Application.Services.AccountService;
using Messenger.Application.Services.UserService;
using Messenger.Application.Services.AuthService;
using Messenger.Application.Services.ChannelService;
using Messenger.Application.Services.ChatService;
using Messenger.Domain.Common;
using Messenger.Domain.Services;
using Messenger.Infrastructure.RabbitMQ;
using Messenger.Persistence.UnitOfWork;

namespace Messenger.WebApi.ApiBuilder.ServiceManager;

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
