namespace Messenger.Application.Services.ChannelService.Models;

public class ChannelServiceCreatePrivateChannelRequest
{
    public required string Name { get; set; }
    public IEnumerable<int> Members { get; set; } = [];
}
