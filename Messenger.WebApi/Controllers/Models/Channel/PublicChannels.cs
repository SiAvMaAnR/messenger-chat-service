using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Channel;

public class ChannelControllerPublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
