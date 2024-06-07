using MessengerX.Application.Services.ChatService.Adapters;
using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChatService;

public class ChatService : BaseService, IChatService
{
    private readonly ChatBS _chatBS;

    public ChatService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        ChatBS chatBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _chatBS = chatBS;
    }

    public async Task<ChatServiceMessagesResponse> MessagesAsync(ChatServiceMessagesRequest request)
    {
        IEnumerable<Message> messages = await _chatBS.MessagesAsync(
            request.ChannelId,
            request.SearchField
        );

        PaginatorResponse<Message> paginatedData = messages.Pagination(request.Pagination);

        var adaptedMessages = paginatedData
            .Collection
            .Select(message => new ChatServiceMessageAdapter(message))
            .ToList();

        return new ChatServiceMessagesResponse()
        {
            Meta = paginatedData.Meta,
            Messages = adaptedMessages
        };
    }

    public async Task<ChatServiceSendMessageResponse> SendMessageAsync(
        ChatServiceSendMessageRequest request
    )
    {
        var message = new Message(UserId, request.ChannelId) { Text = request.Message };

        await _chatBS.AddMessageAsync(request.ChannelId, message);

        IEnumerable<string> userIds = await _chatBS.GetUserIdsByChannelIdAsync(
            UserId,
            request.ChannelId
        );

        return new ChatServiceSendMessageResponse()
        {
            UserIds = userIds,
            Message = new ChatServiceMessageAdapter(message)
        };
    }
}
