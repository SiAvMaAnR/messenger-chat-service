using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.Infrastructure.AppSettings;
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

        var channel = new Channel()
        {
            Type = ChannelType.Direct,
            Accounts = [myAccount, otherAccount]
        };

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

        var channel = new Channel()
        {
            Type = ChannelType.Private,
            Accounts = [myAccount],
            Name = request.Name
        };

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

        var channel = new Channel()
        {
            Type = ChannelType.Public,
            Accounts = [myAccount],
            Name = request.Name
        };

        await _unitOfWork.Channel.AddAsync(channel);
        await _unitOfWork.SaveChangesAsync();

        return new ChannelServiceCreatePublicChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    )
    {
        Account myAccount =
            await _unitOfWork.Account.GetAsync(account => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        return new ChannelServiceConnectToChannelResponse() { IsSuccess = true };
    }
}
