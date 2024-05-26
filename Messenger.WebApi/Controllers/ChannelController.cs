using MessengerX.Application.Services.ChannelService;
using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.WebApi.Controllers.Models.Channel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChannelController : ControllerBase
{
    private readonly IChannelService _channelService;

    public ChannelController(IChannelService channelService)
    {
        _channelService = channelService;
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

    [HttpPost("join"), Authorize]
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
}
