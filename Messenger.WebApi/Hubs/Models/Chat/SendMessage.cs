namespace MessengerX.WebApi.Hubs.Models.Chat;

public class ChatHubSendMessageRequest
{
    public int ChannelId { get; set; }
    public required string Message { get; set; }
}
