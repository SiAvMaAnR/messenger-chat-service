using MessengerX.Domain.Entities.Messages;

namespace MessengerX.Application.Services.ChatService.Models;

public class ChatServiceSendMessageResponse
{
    public IEnumerable<int> UserIds { get; set; } = [];
    public required Message Message { get; set; }
}
