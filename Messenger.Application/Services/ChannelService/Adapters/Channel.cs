using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.Persistence.Extensions;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChannelServiceChannelAdapter : ChannelServiceChannelResponseData
{
    private readonly string? _imagePath;

    public ChannelServiceChannelAdapter(Channel channel, int? authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;

        Message? lastMessage = channel.GetLastMessage();

        LastMessage = new ChannelServiceLastMessageResponseData()
        {
            Author = lastMessage?.Author?.Login,
            Content = lastMessage?.Text
        };

        if (Type == ChannelType.Direct)
        {
            Account? chatPartner = channel
                .Accounts
                .FirstOrDefault(account => account.Id != authorId);

            if (chatPartner != null)
            {
                _imagePath = chatPartner.Image;
                Name = chatPartner.Login;
            }
        }
        else
        {
            _imagePath = channel.Image;
            Name = channel.Name;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
