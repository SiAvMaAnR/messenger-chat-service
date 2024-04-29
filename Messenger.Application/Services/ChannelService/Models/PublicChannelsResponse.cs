using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChannelService.Models;

public class ChannelServiceChannelResponsePayload
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime LastActivity { get; set; }
}

public class ChannelServicePublicChannelsResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChannelServiceChannelResponsePayload>? Channels { get; set; }
}
