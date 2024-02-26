namespace MessengerX.Application.Services.ChatService.Models;

public class ChatServiceSendMessageRequest
{
    public int ChannelId { get; set; }
    public string Message { get; set; } = null!;
}
