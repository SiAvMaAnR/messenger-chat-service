namespace Messenger.WebApi.Hubs.Models.Chat;

public class ChatHubSendMessageRequest
{
    public required int ChannelId { get; set; }
    public required string Message { get; set; }
}
