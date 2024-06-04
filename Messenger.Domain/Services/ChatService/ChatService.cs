using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Exceptions;

namespace MessengerX.Domain.Services;

public class ChatBS : DomainService
{
    public ChatBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<IEnumerable<Message>> MessagesAsync(int channelId, string? searchField)
    {
        IEnumerable<Message>? messages = await _unitOfWork
            .Message
            .GetAllAsync(new MessagesSpec(channelId, searchField));

        if (messages == null)
            throw new NotExistsException("Messages not exists");

        return messages;
    }

    public async Task AddMessageAsync(int channelId, Message message)
    {
        Channel? channel = await _unitOfWork
            .Channel
            .GetAsync(new AccountChannelSpec(message.AuthorId, channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        channel.AddMessage(message);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<string>> GetUserIdsByChannelIdAsync(int accountId, int channelId)
    {
        Channel? channel = await _unitOfWork
            .Channel
            .GetAsync(new AccountChannelSpec(accountId, channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        IEnumerable<string> userIds = channel.Accounts.Select(account => account.Id.ToString());

        return userIds;
    }
}
