using Messenger.WebApi.Hubs.Common;
using MessengerX.Application.Services.ChannelService;
using MessengerX.Application.Services.ChatService;
using MessengerX.Application.Services.ChatService.Models;
using MessengerX.WebApi.Hubs.Models.Chat;
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

    [Authorize]
    public async Task SendMessageAsync(ChatHubSendMessageRequest request)
    {
        ChatServiceSendMessageResponse response = await _chatService.SendMessageAsync(
            new ChatServiceSendMessageRequest()
            {
                ChannelId = request.ChannelId,
                Message = request.Message
            }
        );



    }
}
