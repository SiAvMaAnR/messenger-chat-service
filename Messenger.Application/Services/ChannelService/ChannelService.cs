using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Constants.Common;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChannelService;

public class ChannelService : BaseService, IChannelService
{
    public ChannelService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings
    )
        : base(unitOfWork, context, appSettings) { }

    public async Task<ChannelServiceCreateDirectChannelResponse> CreateDirectChannelAsync(
        ChannelServiceCreateDirectChannelRequest request
    )
    {
        Account? myAccount = await _unitOfWork
            .Account
            .GetAsync(account => account.Id == _userIdentity.Id);

        Account? otherAccount = await _unitOfWork
            .Account
            .GetAsync(account => account.Id == request.AccountId);

        if (myAccount == null || otherAccount == null)
            throw new NotExistsException("Account not found");

        bool isExistsSameDirectChannel = await _unitOfWork
            .Channel
            .AnyAsync(
                (channel) =>
                    channel.Type == ChannelType.Direct
                    && channel.Accounts.Contains(myAccount)
                    && channel.Accounts.Contains(otherAccount)
            );

        if (isExistsSameDirectChannel)
            throw new AlreadyExistsException("This channel name already exists");

        var channel = new Channel(ChannelType.Direct);

        channel.AddAccounts([myAccount, otherAccount]);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();

        return new ChannelServiceCreateDirectChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePrivateChannelResponse> CreatePrivateChannelAsync(
        ChannelServiceCreatePrivateChannelRequest request
    )
    {
        Account myAccount =
            await _unitOfWork.Account.GetAsync(account => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        if (await _unitOfWork.Channel.AnyAsync(channel => channel.Name == request.Name))
            throw new AlreadyExistsException("This channel name already exists");

        var channel = new Channel(ChannelType.Private) { Name = request.Name };

        channel.AddAccount(myAccount);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();

        return new ChannelServiceCreatePrivateChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePublicChannelResponse> CreatePublicChannelAsync(
        ChannelServiceCreatePublicChannelRequest request
    )
    {
        Account myAccount =
            await _unitOfWork.Account.GetAsync(account => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        if (await _unitOfWork.Channel.AnyAsync(channel => channel.Name == request.Name))
            throw new AlreadyExistsException("This channel name already exists");

        var channel = new Channel(ChannelType.Public) { Name = request.Name };

        channel.AddAccount(myAccount);

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();

        return new ChannelServiceCreatePublicChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        Channel channel =
            await _unitOfWork.Channel.GetAsync(channel => channel.Id == request.ChannelId)
            ?? throw new NotExistsException("Channel not found");

        if (channel.Type != ChannelType.Public || channel.Accounts.Contains(account))
            throw new IncorrectDataException("Invalid channel");

        channel.AddAccount(account);
        await _unitOfWork.SaveChangesAsync();

        return new ChannelServiceConnectToChannelResponse() { IsSuccess = true };
    }
}
