using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.ChannelService.Models;

public class ChannelServiceLastMessageResponseData
{
    public string? Content { get; set; }
    public string? Author { get; set; }
}

public class ChannelServiceAccountChannelResponseData
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime LastActivity { get; set; }
    public byte[]? Image { get; set; }
    public ChannelServiceLastMessageResponseData? LastMessage { get; set; }
    public int UnreadMessagesCount { get; set; }
}

public class ChannelServiceAccountChannelsResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChannelServiceAccountChannelResponseData>? Channels { get; set; }
}
