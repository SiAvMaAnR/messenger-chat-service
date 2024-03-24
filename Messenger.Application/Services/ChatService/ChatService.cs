using MessengerX.Application.Services.ChatService.Adapters;
using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.Helpers;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChatService;

public class ChatService : BaseService, IChatService
{
    public ChatService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings
    )
        : base(unitOfWork, context, appSettings) { }

    public async Task<ChatServiceChannelsResponse> ChannelsAsync(ChatServiceChannelsRequest request)
    {
        Account account =
            await _unitOfWork
                .Account
                .GetAsync(account => account.Id == _userIdentity.Id, account => account.Channels)
            ?? throw new NotExistsException("Account not found");

        ICollection<Channel> channels = account.Channels;

        Pagination? pagination = request.Pagination;

        IOrderedEnumerable<Channel> sortedChannels = channels.OrderBy(channel => channel.Id);

        PaginatorResponse<Channel> paginatedData = sortedChannels.Pagination(pagination);

        var adaptedChannels = paginatedData
            .Collection
            .Select(channel => new ChatServiceChannelAdapter(channel))
            .ToList();

        return new ChatServiceChannelsResponse()
        {
            Meta = paginatedData.Meta,
            Channels = adaptedChannels
        };
    }

    public Task<ChatServiceSendMessageResponse> SendMessageAsync(
        ChatServiceSendMessageRequest request
    )
    {
        throw new NotImplementedException();
    }
}
