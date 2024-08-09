namespace Messenger.WebApi.Hubs.Models.Chat;

public class ChatHubReadMessageRequest
{
    public required int ChannelId { get; set; }
    public required int MessageId { get; set; }
}
