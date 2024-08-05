using Messenger.Domain.Common;

namespace Messenger.Infrastructure.RabbitMQ;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IAppSettings _appSettings;

    public RabbitMQConsumer(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }
}
