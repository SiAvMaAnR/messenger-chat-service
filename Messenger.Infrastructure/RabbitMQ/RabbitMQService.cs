using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace MessengerX.Infrastructure.RabbitMQ;

public class RabbitMQService : IRabbitMQService
{
    public void SendMessage(object obj)
    {
        string message = JsonSerializer.Serialize(obj);
        SendMessage(message);
    }

    public void SendMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        using IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "ai-queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        byte[] body = Encoding.UTF8.GetBytes(message);

        IBasicProperties properties = channel.CreateBasicProperties();
        properties.Headers = new Dictionary<string, object> { { "pattern", "create-message" } };

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "ai-queue",
            basicProperties: properties,
            body: body
        );
    }
}
