using MessengerX.Domain.Common;

namespace MessengerX.Infrastructure.RabbitMQ;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IAppSettings _appSettings;

    public RabbitMQConsumer(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }
}
