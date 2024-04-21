using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChatService.Models;

public class ChatServiceChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
