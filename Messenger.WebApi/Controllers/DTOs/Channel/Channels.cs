using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Channel;

public class ChannelControllerChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
