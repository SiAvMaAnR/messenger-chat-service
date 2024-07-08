using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Application.Services.Common;

namespace MessengerX.Application.Services.ChatService;

public interface IChatService : IBaseService
{
    Task<ChatServiceSendMessageResponse> SendMessageAsync(ChatServiceSendMessageRequest request);
    Task<ChatServiceReadMessageResponse> ReadMessageAsync(ChatServiceReadMessageRequest request);
    Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request);
}
