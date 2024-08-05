using Messenger.Application.Services.ChatService.Models;
using Messenger.Application.Services.Common;

namespace Messenger.Application.Services.ChatService;

public interface IChatService : IBaseService
{
    Task<ChatServiceSendMessageResponse> SendMessageAsync(ChatServiceSendMessageRequest request);
    Task<ChatServiceReadMessageResponse> ReadMessageAsync(ChatServiceReadMessageRequest request);
    Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request);
}
