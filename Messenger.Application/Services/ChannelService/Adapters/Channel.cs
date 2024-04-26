using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Domain.Entities.Channels;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChannelServiceChannelAdapter : ChannelServiceChannelResponsePayload
{
    public ChannelServiceChannelAdapter(Channel channel)
    {
        Name = channel.Name;
        Type = channel.Type;
        LastActivity = channel.LastActivity;
    }
}
