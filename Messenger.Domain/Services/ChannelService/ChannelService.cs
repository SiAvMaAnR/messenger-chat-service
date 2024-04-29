using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Exceptions;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Services;

public class ChannelBS : DomainService
{
    public ChannelBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task CreateDirectChannelAsync(int? firstAccountId, int? secondAccountId)
    {
        Account? firstAccount = await _unitOfWork
            .Account
            .GetAsync(account => account.Id == firstAccountId);

        Account? secondAccount = await _unitOfWork
            .Account
            .GetAsync(account => account.Id == secondAccountId);

        if (firstAccount == null || secondAccount == null)
            throw new NotExistsException("Account not found");

        bool isExistsSameDirectChannel = await _unitOfWork
            .Channel
            .AnyAsync(
                (channel) =>
                    channel.Type == ChannelType.Direct
                    && channel.Accounts.Contains(firstAccount)
                    && channel.Accounts.Contains(secondAccount)
            );

        if (isExistsSameDirectChannel)
            throw new AlreadyExistsException("This channel already exists");

        var channel = new Channel(ChannelType.Direct);

        channel.AddAccounts([firstAccount, secondAccount]);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task CreatePrivateChannelAsync(int? accountId, string channelName)
    {
        Account myAccount =
            await _unitOfWork.Account.GetAsync(account => account.Id == accountId)
            ?? throw new NotExistsException("Account not found");

        if (await _unitOfWork.Channel.AnyAsync(channel => channel.Name == channelName))
            throw new AlreadyExistsException("This channel name already exists");

        var channel = new Channel(ChannelType.Private) { Name = channelName };

        channel.AddAccount(myAccount);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task CreatePublicChannelAsync(int? accountId, string channelName)
    {
        Account myAccount =
            await _unitOfWork.Account.GetAsync(account => account.Id == accountId)
            ?? throw new NotExistsException("Account not found");

        if (await _unitOfWork.Channel.AnyAsync(channel => channel.Name == channelName))
            throw new AlreadyExistsException("This channel name already exists");

        var channel = new Channel(ChannelType.Public) { Name = channelName };

        channel.AddAccount(myAccount);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ConnectToChannelAsync(int? accountId, int channelId)
    {
        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Id == accountId)
            ?? throw new NotExistsException("Account not found");

        Channel channel =
            await _unitOfWork.Channel.GetAsync(channel => channel.Id == channelId)
            ?? throw new NotExistsException("Channel not found");

        if (channel.Type != ChannelType.Public || channel.Accounts.Contains(account))
            throw new IncorrectDataException("Invalid channel");

        channel.AddAccount(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Channel>> PublicChannelsAsync(string? searchField)
    {
        IEnumerable<Channel>? channels = await _unitOfWork
            .Channel
            .GetAllAsync(
                channel =>
                    channel.Type == ChannelType.Public
                    && (
                        searchField == null
                        || channel.Name != null && channel.Name.Contains(searchField)
                    )
            );

        if (channels == null)
            throw new NotExistsException("Channels not exists");

        return channels;
    }
}
