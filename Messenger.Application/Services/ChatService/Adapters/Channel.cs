using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Domain.Entities.Channels;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChatServiceChannelAdapter : ChatServiceChannelResponsePayload
{
    public ChatServiceChannelAdapter(Channel channel)
    {
        Name = channel.Name;
        Type = channel.Type;
        LastActivity = channel.LastActivity;
    }
}
