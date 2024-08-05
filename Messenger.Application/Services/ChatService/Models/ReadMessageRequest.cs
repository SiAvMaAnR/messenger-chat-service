namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceReadMessageRequest
{
    public required int ChannelId { get; set; }
    public required int MessageId { get; set; }
}
