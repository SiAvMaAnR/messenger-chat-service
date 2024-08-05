namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceSendMessageRequest
{
    public int ChannelId { get; set; }
    public required string Message { get; set; }
}
