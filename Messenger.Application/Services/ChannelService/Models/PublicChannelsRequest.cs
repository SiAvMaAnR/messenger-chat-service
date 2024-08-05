using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.ChannelService.Models;

public class ChannelServicePublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
