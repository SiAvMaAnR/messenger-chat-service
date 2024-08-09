using Messenger.WebApi.Hubs;
using Messenger.WebApi.Hubs.Common;
using Messenger.Application.Services.ChannelService;
using Messenger.Application.Services.ChannelService.Models;
using Messenger.WebApi.Controllers.Models.Channel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChannelController : ControllerBase
{
    private readonly IChannelService _channelService;
    private readonly IHubContext<ChatHub> _chatHubContext;

    public ChannelController(IChannelService channelService, IHubContext<ChatHub> chatHubContext)
    {
        _channelService = channelService;
        _chatHubContext = chatHubContext;
    }

    [HttpPost("create-direct"), Authorize]
    public async Task<IActionResult> CreateDirectChannel(
        [FromBody] ChannelControllerCreateDirectChannelRequest request
    )
    {
        ChannelServiceCreateDirectChannelResponse response =
            await _channelService.CreateDirectChannelAsync(
                new ChannelServiceCreateDirectChannelRequest() { AccountId = request.AccountId }
            );

        return Ok(response);
    }

    [HttpPost("create-public"), Authorize]
    public async Task<IActionResult> CreatePublicChannel(
        [FromBody] ChannelControllerCreatePublicChannelRequest request
    )
    {
        ChannelServiceCreatePublicChannelResponse response =
            await _channelService.CreatePublicChannelAsync(
                new ChannelServiceCreatePublicChannelRequest()
                {
                    Name = request.Name,
                    Members = request.Members
                }
            );

        return Ok(response);
    }

    [HttpPost("create-private"), Authorize]
    public async Task<IActionResult> CreatePrivateChannel(
        [FromBody] ChannelControllerCreatePrivateChannelRequest request
    )
    {
        ChannelServiceCreatePrivateChannelResponse response =
            await _channelService.CreatePrivateChannelAsync(
                new ChannelServiceCreatePrivateChannelRequest()
                {
                    Name = request.Name,
                    Members = request.Members
                }
            );

        return Ok(response);
    }

    [HttpPost("join-channel"), Authorize]
    public async Task<IActionResult> ConnectToChannel(
        [FromBody] ChannelControllerConnectToChannelRequest request
    )
    {
        ChannelServiceConnectToChannelResponse response =
            await _channelService.ConnectToChannelAsync(
                new ChannelServiceConnectToChannelRequest() { ChannelId = request.ChannelId }
            );

        return Ok(response);
    }

    [HttpGet("public-channels"), Authorize]
    public async Task<IActionResult> GetPublicChannels(
        [FromQuery] ChannelControllerPublicChannelsRequest request
    )
    {
        ChannelServicePublicChannelsResponse response = await _channelService.PublicChannelsAsync(
            new ChannelServicePublicChannelsRequest()
            {
                SearchField = request.SearchField,
                Pagination = request.Pagination
            }
        );

        return Ok(response);
    }

    [HttpGet("account-channels"), Authorize]
    public async Task<IActionResult> GetAccountChannels(
        [FromQuery] ChannelControllerAccountChannelsRequest request
    )
    {
        ChannelServiceAccountChannelsResponse response = await _channelService.AccountChannelsAsync(
            new ChannelServiceAccountChannelsRequest()
            {
                SearchField = request.SearchField,
                ChannelType = request.ChannelType,
                Pagination = request.Pagination
            }
        );

        return Ok(response);
    }

    [HttpGet("account-channels/{id:int}"), Authorize]
    public async Task<IActionResult> GetAccountChannel([FromRoute] int id)
    {
        ChannelServiceAccountChannelResponse response = await _channelService.AccountChannelAsync(
            new ChannelServiceAccountChannelRequest() { Id = id }
        );

        return Ok(response);
    }

    [HttpPost("setup-direct"), Authorize]
    public async Task<IActionResult> SetUpDirectChannel(
        [FromBody] ChannelControllerSetUpDirectChannelRequest request
    )
    {
        ChannelServiceSetUpDirectChannelResponse response =
            await _channelService.SetUpDirectChannelAsync(
                new ChannelServiceSetUpDirectChannelRequest() { PartnerId = request.PartnerId }
            );

        if (response.IsNeedNotifyUsers)
        {
            await _chatHubContext
                .Clients
                .Users(response.UserIds)
                .SendAsync(ChatHubMethod.ChannelResponse, response.DirectChannel);
        }

        return Ok(response.DirectChannel?.Id);
    }

    [HttpGet("member-images"), Authorize]
    public async Task<IActionResult> GetMemberImages(
        [FromQuery] ChannelControllerMemberImagesRequest request
    )
    {
        ChannelServiceMemberImagesResponse response = await _channelService.MemberImagesAsync(
            new ChannelServiceMemberImagesRequest() { ChannelId = request.ChannelId }
        );

        return Ok(response);
    }
}
