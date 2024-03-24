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
                new ChannelServiceCreatePublicChannelRequest() { Name = request.Name }
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
                new ChannelServiceCreatePrivateChannelRequest() { Name = request.Name }
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

    // TEMP TEMPLATE
    [HttpGet("public-channels"), Authorize]
    public async Task<IActionResult> PublicChannels(
        [FromBody] ChannelControllerCreatePrivateChannelRequest request
    )
    {
        ChannelServiceCreatePrivateChannelResponse response =
            await _channelService.CreatePrivateChannelAsync(
                new ChannelServiceCreatePrivateChannelRequest() { Name = request.Name }
            );

        return Ok(response);
    }
}
