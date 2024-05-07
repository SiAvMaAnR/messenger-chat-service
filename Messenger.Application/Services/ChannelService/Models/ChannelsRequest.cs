using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChannelService.Models;

public class ChannelServiceChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
