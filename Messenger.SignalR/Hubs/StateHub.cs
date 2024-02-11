using Messenger.SignalR.Hubs.Common;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Http;

namespace Messenger.SignalR.Hubs;

public class StateHub : BaseHub, IHub
{
    public StateHub(IUnitOfWork unitOfWork, IHttpContextAccessor context, IAppSettings appSettings)
        : base(unitOfWork, context, appSettings) { 


            
        }
}
