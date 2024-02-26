using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Interfaces.UnitOfWork;
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

    public Task<ChatServiceSendMessageResponse> SendMessageAsync(
        ChatServiceSendMessageRequest request
    )
    {
        throw new NotImplementedException();
    }
}
