using Messenger.Domain.Shared.Models;

namespace Messenger.WebApi.Controllers.Models.Chat;

public class ChatControllerMessagesRequest
{
    public int ChannelId { get; set; }
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
