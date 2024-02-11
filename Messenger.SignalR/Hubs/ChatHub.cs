using Messenger.SignalR.Hubs.Common;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Http;

namespace Messenger.SignalR.Hubs;

public class ChatHub : BaseHub, IHub
{
    public ChatHub(IUnitOfWork unitOfWork, IHttpContextAccessor context, IAppSettings appSettings)
        : base(unitOfWork, context, appSettings)
    {



    }
}
