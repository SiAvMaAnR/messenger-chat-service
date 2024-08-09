using Messenger.Application.Services.ChannelService.Models;
using Messenger.Application.Services.ChatService.Adapters;
using Messenger.Application.Services.Common;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Channels;
using Messenger.Domain.Exceptions;
using Messenger.Domain.Services;
using Messenger.Persistence.Extensions;
using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.ChannelService;

public class ChannelService : BaseService, IChannelService
{
    private readonly ChannelBS _channelBS;

    public ChannelService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        ChannelBS channelBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _channelBS = channelBS;
    }

    public async Task<ChannelServiceCreateDirectChannelResponse> CreateDirectChannelAsync(
        ChannelServiceCreateDirectChannelRequest request
    )
    {
        await _channelBS.CreateDirectChannelAsync(UserId, request.AccountId);

        return new ChannelServiceCreateDirectChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePrivateChannelResponse> CreatePrivateChannelAsync(
        ChannelServiceCreatePrivateChannelRequest request
    )
    {
        await _channelBS.CreatePrivateChannelAsync(UserId, request.Name, request.Members);

        return new ChannelServiceCreatePrivateChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePublicChannelResponse> CreatePublicChannelAsync(
        ChannelServiceCreatePublicChannelRequest request
    )
    {
        await _channelBS.CreatePublicChannelAsync(UserId, request.Name, request.Members);

        return new ChannelServiceCreatePublicChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    )
    {
        await _channelBS.ConnectToChannelAsync(UserId, request.ChannelId);

        return new ChannelServiceConnectToChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServicePublicChannelsResponse> PublicChannelsAsync(
        ChannelServicePublicChannelsRequest request
    )
    {
        IEnumerable<Channel> channels = await _channelBS.PublicChannelsAsync(request.SearchField);

        PaginatorResponse<Channel> paginatedData = channels.Pagination(request.Pagination);

        var adaptedChannels = paginatedData
            .Collection
            .Select(channel => new ChannelServicePublicChannelAdapter(channel, UserId))
            .ToList();

        await Task.WhenAll(adaptedChannels.Select(channel => channel.LoadImageAsync()));

        return new ChannelServicePublicChannelsResponse()
        {
            Meta = paginatedData.Meta,
            Channels = adaptedChannels
        };
    }

    public async Task<ChannelServiceAccountChannelsResponse> AccountChannelsAsync(
        ChannelServiceAccountChannelsRequest request
    )
    {
        IEnumerable<Channel> channels = await _channelBS.AccountChannelsAsync(
            UserId,
            request.SearchField,
            request.ChannelType
        );

        PaginatorResponse<Channel> paginatedData = channels.Pagination(request.Pagination);

        var adaptedChannels = paginatedData
            .Collection
            .Select(channel => new ChannelServiceAccountChannelListAdapter(channel, UserId))
            .ToList();

        await Task.WhenAll(adaptedChannels.Select(channel => channel.LoadImageAsync()));

        return new ChannelServiceAccountChannelsResponse()
        {
            Meta = paginatedData.Meta,
            Channels = adaptedChannels
        };
    }

    public async Task<ChannelServiceAccountChannelResponse> AccountChannelAsync(
        ChannelServiceAccountChannelRequest request
    )
    {
        Channel channel = await _channelBS.AccountChannelAsync(UserId, request.Id);

        var adaptedChannel = new ChannelServiceAccountChannelAdapter(channel, UserId);

        await adaptedChannel.LoadImageAsync();

        return adaptedChannel;
    }

    public async Task<ChannelServiceSetUpDirectChannelResponse> SetUpDirectChannelAsync(
        ChannelServiceSetUpDirectChannelRequest request
    )
    {
        Channel? channel = await _channelBS.AccountDirectChannelAsync(UserId, request.PartnerId);

        Channel? directChannel;
        bool isNeedNotify = false;

        if (channel != null)
        {
            directChannel = channel;
        }
        else
        {
            Channel newChannel = await _channelBS.CreateDirectChannelAsync(
                UserId,
                request.PartnerId
            );

            directChannel = await _channelBS.AccountDirectChannelAsync(UserId, request.PartnerId);
            isNeedNotify = true;
        }

        if (directChannel == null)
            throw new NotExistsException("Channel not exists");

        IEnumerable<string> userIds = directChannel
            .Accounts
            .Select(account => account.Id.ToString());

        var adaptedChannel = new ChannelServiceDirectChannelAdapter(directChannel, UserId);

        await adaptedChannel.LoadImageAsync();

        return new ChannelServiceSetUpDirectChannelResponse()
        {
            DirectChannel = adaptedChannel,
            UserIds = userIds,
            IsNeedNotifyUsers = isNeedNotify
        };
    }

    public async Task<ChannelServiceMemberImagesResponse> MemberImagesAsync(
        ChannelServiceMemberImagesRequest request
    )
    {
        Channel channel = await _channelBS.AccountChannelAsync(UserId, request.ChannelId);

        ICollection<Account> accounts = channel.Accounts;

        IEnumerable<Task<ChannelServiceMemberImageResponseData>> memberImageTasks = accounts.Select(
            async (account) =>
            {
                byte[]? image = await FileManager.ReadToBytesAsync(account.Image);
                return new ChannelServiceMemberImageResponseData()
                {
                    Id = account.Id,
                    Image = image
                };
            }
        );

        ChannelServiceMemberImageResponseData[] memberImages = await Task.WhenAll(memberImageTasks);

        return new ChannelServiceMemberImagesResponse() { MemberImages = memberImages };
    }
}
