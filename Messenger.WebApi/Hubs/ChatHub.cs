using Messenger.WebApi.Hubs.Common;
using MessengerX.Application.Services.ChannelService;
using MessengerX.Application.Services.ChatService;
using MessengerX.Application.Services.ChatService.Models;
using Microsoft.AspNetCore.Authorization;

namespace Messenger.WebApi.Hubs;

public class ChatHub(IChatService chatService, IChannelService channelService) : BaseHub, IHub
{
    private readonly IChatService _chatService = chatService;
    private readonly IChannelService _channelService = channelService;

    [Authorize]
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessageAsync(int channelId, string message)
    {
        await _chatService.SendMessageAsync(
            new ChatServiceSendMessageRequest() { ChannelId = channelId, Message = message }
        );
    }
}
