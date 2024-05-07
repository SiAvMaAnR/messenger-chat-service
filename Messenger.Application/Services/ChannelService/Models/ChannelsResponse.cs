using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChannelService.Models;

public class ChannelServiceLastMessageResponseData
{
    public string? Content { get; set; }
    public string? Author { get; set; }
}

public class ChannelServiceChannelResponseData
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime LastActivity { get; set; }
    public byte[]? Image { get; set; }
    public ChannelServiceLastMessageResponseData? LastMessage { get; set; }

}

public class ChannelServiceChannelsResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChannelServiceChannelResponseData>? Channels { get; set; }
}
