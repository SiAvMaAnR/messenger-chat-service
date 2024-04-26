using MessengerX.Application.Services.ChatService;
using MessengerX.Application.Services.ChatService.Models;
using MessengerX.WebApi.Controllers.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("channels"), Authorize]
    public async Task<IActionResult> GetChannels([FromQuery] ChatControllerChannelsRequest request)
    {
        ChatServiceChannelsResponse response = await _chatService.ChannelsAsync(
            new ChatServiceChannelsRequest()
            {
                SearchField = request.SearchField,
                Pagination = request.Pagination
            }
        );

        return Ok(response);
    }
}
