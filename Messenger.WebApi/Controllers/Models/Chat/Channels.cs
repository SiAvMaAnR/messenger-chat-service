using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Chat;

public class ChatControllerChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
