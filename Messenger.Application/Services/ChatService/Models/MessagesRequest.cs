using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.ChatService.Models;

public class ChatServiceMessagesRequest
{
    public int ChannelId { get; set; }
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
