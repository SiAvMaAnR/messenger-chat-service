using Messenger.Domain.Shared.Models;

namespace Messenger.WebApi.Controllers.Models.Channel;

public class ChannelControllerPublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
