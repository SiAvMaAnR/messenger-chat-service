using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.ChatService.Adapters;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Channels;
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

        PaginatorResponse<Channel> paginatedData = channels.Pagination(request.Pagination);

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
            .Select(channel => new ChannelServiceAccountChannelAdapter(channel, _userIdentity.Id))
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

        var adaptedChannel = new ChannelServiceAccountChannelForOneAdapter(
            channel,
            _userIdentity.Id
        );

        await adaptedChannel.LoadImageAsync();

        return adaptedChannel;
    }
}
