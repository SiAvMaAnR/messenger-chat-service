using Messenger.Application.Services.ChatService.Adapters;
using Messenger.Application.Services.ChatService.Models;
using Messenger.Application.Services.Common;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.ChatService;

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

    public async Task<ChatServiceReadMessageResponse> ReadMessageAsync(
        ChatServiceReadMessageRequest request
    )
    {
        IEnumerable<Message> readMessages = await _chatBS.ReadMessagesAsync(
            request.ChannelId,
            request.MessageId,
            UserId
        );

        IEnumerable<string> userIds = await _chatBS.GetUserIdsByChannelIdAsync(
            UserId,
            request.ChannelId
        );

        int unreadMessagesCount = await _chatBS.GetUnreadMessagesCountAsync(
            UserId,
            request.ChannelId
        );

        return new ChatServiceReadMessageResponse()
        {
            ReadMessageIds = readMessages.Select(message => message.Id),
            UserIds = userIds,
            UnreadMessagesCount = unreadMessagesCount
        };
    }
}
