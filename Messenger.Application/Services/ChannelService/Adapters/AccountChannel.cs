using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.Persistence.Extensions;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChannelServiceAccountChannelAdapter : ChannelServiceAccountChannelResponseData
{
    private readonly string? _imagePath;

    public ChannelServiceAccountChannelAdapter(Channel channel, int? authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;

        Message? lastMessage = channel.GetLastMessage();

        if (lastMessage != null)
        {
            LastMessage = new ChannelServiceLastMessageResponseData()
            {
                Author = lastMessage.Author?.Login,
                Content = lastMessage.Text
            };
        }

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

public class ChannelServiceAccountChannelForOneAdapter : ChannelServiceAccountChannelResponse
{
    private readonly string? _imagePath;

    public ChannelServiceAccountChannelForOneAdapter(Channel channel, int? authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;

        if (Type == ChannelType.Direct)
        {
            Account? chatPartner = channel
                .Accounts
                .FirstOrDefault(account => account.Id != authorId);

            if (chatPartner != null)
            {
                _imagePath = chatPartner.Image;
                Name = chatPartner.Login;
                UserActivityStatus = chatPartner.ActivityStatus;
                UserLastOnlineAt = chatPartner.LastOnlineAt;
            }
        }
        else
        {
            _imagePath = channel.Image;
            Name = channel.Name;
            MembersCount = channel.Accounts.Count;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
