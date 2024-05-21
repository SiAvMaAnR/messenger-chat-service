using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.ChatService.Adapters;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Exceptions;
using MessengerX.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChannelService;

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

        IOrderedEnumerable<Channel> sortedChannels = channels.OrderBy(channel => channel.Id);

        PaginatorResponse<Channel> paginatedData = sortedChannels.Pagination(request.Pagination);

        var adaptedChannels = paginatedData
            .Collection
            .Select(channel => new ChannelServicePublicChannelAdapter(channel, _userIdentity.Id))
            .ToList();

        await Task.WhenAll(adaptedChannels.Select(channel => channel.LoadImageAsync()));

        return new ChannelServicePublicChannelsResponse()
        {
            Meta = paginatedData.Meta,
            Channels = adaptedChannels
        };
    }

    public async Task<ChannelServiceChannelsResponse> AccountChannelsAsync(
        ChannelServiceChannelsRequest request
    )
    {
        IEnumerable<Channel> channels = await _channelBS.AccountChannelsAsync(
            _userIdentity.Id,
            request.SearchField
        );

        if (channels == null)
            throw new NotExistsException("Channels not found");

        IOrderedEnumerable<Channel> sortedChannels = channels.OrderByDescending(
            channel => channel.LastActivity
        );

        PaginatorResponse<Channel> paginatedData = sortedChannels.Pagination(request.Pagination);

        var adaptedChannels = paginatedData
            .Collection
            .Select(channel => new ChannelServiceChannelAdapter(channel, _userIdentity.Id))
            .ToList();

        await Task.WhenAll(adaptedChannels.Select(channel => channel.LoadImageAsync()));

        return new ChannelServiceChannelsResponse()
        {
            Meta = paginatedData.Meta,
            Channels = adaptedChannels
        };
    }
}
