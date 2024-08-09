using Messenger.Application.Services.ChannelService.Models;
using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Channels;
using Messenger.Domain.Entities.Messages;
using Messenger.Persistence.Extensions;

public class ChannelServiceDirectChannelAdapter : ChannelServiceDirectChannel
{
    private readonly string? _imagePath;

    public ChannelServiceDirectChannelAdapter(Channel channel, int authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;

        Message? lastMessage = channel.GetLastMessage();

        if (lastMessage != null)
        {
            LastMessage = new ChannelServiceLastMessageForOneResponseData()
            {
                Author = lastMessage.Author?.Login,
                Content = lastMessage.Text
            };
        }

        Account? chatPartner = channel.Accounts.FirstOrDefault(account => account.Id != authorId);

        if (chatPartner != null)
        {
            _imagePath = chatPartner.Image;
            Name = chatPartner.Login;
            UserActivityStatus = chatPartner.ActivityStatus;
            UserLastOnlineAt = chatPartner.LastOnlineAt;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
