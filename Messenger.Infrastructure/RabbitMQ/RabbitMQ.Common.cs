using System.Text;
using System.Text.Json;
using Messenger.Domain.Common;
using RabbitMQ.Client;

namespace Messenger.Infrastructure.RabbitMQ;

public static class RabbitMQ
{
    public static IConnection CreateConnection(IAppSettings appSettings)
    {
        var factory = new ConnectionFactory()
        {
            HostName = appSettings.RMQ.HostName,
            UserName = appSettings.RMQ.UserName,
            Password = appSettings.RMQ.Password
        };

        return factory.CreateConnection();
    }

    public static byte[] MessageAdapter(object message, string? pattern = null)
    {
        string adaptedMessage = JsonSerializer.Serialize(new { pattern, data = message });

        return Encoding.UTF8.GetBytes(adaptedMessage);
    }

    public static TResponse? Deserialize<TResponse>(string content)
    {
        try
        {
            return JsonSerializer.Deserialize<TResponse>(content);
        }
        catch (Exception)
        {
            throw new JsonException($"Failed deserialization. JSON: {content}");
        }
    }
}

public static class RMQ
{
    public static class Queue
    {
        public const string Ai = "ai-queue";
    }

    public static class Pattern
    {
        public const string CreateMessage = "create-message";
    }
}
