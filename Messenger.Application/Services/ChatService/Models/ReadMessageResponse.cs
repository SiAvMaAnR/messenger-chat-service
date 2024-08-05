namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceReadMessageResponse
{
    public IEnumerable<string> UserIds { get; set; } = [];
    public IEnumerable<int> ReadMessageIds { get; set; } = [];
    public int UnreadMessagesCount { get; set; }
}
