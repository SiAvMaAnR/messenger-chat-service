using Messenger.Application.Services.ChatService;
using Messenger.Application.Services.ChatService.Models;
using Messenger.WebApi.Controllers.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("messages"), Authorize]
    public async Task<IActionResult> GetMessages(
        [FromQuery] ChatControllerMessagesRequest request
    )
    {
        ChatServiceMessagesResponse response = await _chatService.MessagesAsync(
            new ChatServiceMessagesRequest()
            {
                ChannelId = request.ChannelId,
                SearchField = request.SearchField,
                Pagination = request.Pagination
            }
        );

        return Ok(response);
    }
}
