using Messenger.Application.Services.ChannelService.Models;
using Messenger.Application.Services.Common;

namespace Messenger.Application.Services.ChannelService;

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
    Task<ChannelServiceMemberImagesResponse> MemberImagesAsync(
        ChannelServiceMemberImagesRequest request
    );
}
