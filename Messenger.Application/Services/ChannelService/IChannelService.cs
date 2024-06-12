using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.Common;

namespace MessengerX.Application.Services.ChannelService;

public interface IChannelService : IBaseService
{
    Task<ChannelServiceCreatePublicChannelResponse> CreatePublicChannelAsync(
        ChannelServiceCreatePublicChannelRequest request
    );
    Task<ChannelServiceCreatePrivateChannelResponse> CreatePrivateChannelAsync(
        ChannelServiceCreatePrivateChannelRequest request
    );
    Task<ChannelServiceCreateDirectChannelResponse> CreateDirectChannelAsync(
        ChannelServiceCreateDirectChannelRequest request
    );
    Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    );
    Task<ChannelServicePublicChannelsResponse> PublicChannelsAsync(
        ChannelServicePublicChannelsRequest request
    );
    Task<ChannelServiceAccountChannelsResponse> AccountChannelsAsync(
        ChannelServiceAccountChannelsRequest request
    );
    Task<ChannelServiceAccountChannelResponse> AccountChannelAsync(
        ChannelServiceAccountChannelRequest request
    );
    Task<ChannelServiceSetUpDirectChannelResponse> SetUpDirectChannelAsync(
        ChannelServiceSetUpDirectChannelRequest request
    );
}
