using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.ChannelService.Models;

public class ChannelServicePublicChannelResponseData
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime LastActivity { get; set; }
    public byte[]? Image { get; set; }
}

public class ChannelServicePublicChannelsResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChannelServicePublicChannelResponseData>? Channels { get; set; }
}
