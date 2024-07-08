using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Channel;

public class ChannelControllerAccountChannelsRequest
{
    public string? SearchField { get; set; }
    public string? ChannelType { get; set; }
    public Pagination? Pagination { get; set; }
}
