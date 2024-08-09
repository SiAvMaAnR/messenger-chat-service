namespace Messenger.WebApi.Controllers.Models.Channel;

public class ChannelControllerCreatePublicChannelRequest
{
    public required string Name { get; set; }
    public IEnumerable<int> Members { get; set; } = [];
}
