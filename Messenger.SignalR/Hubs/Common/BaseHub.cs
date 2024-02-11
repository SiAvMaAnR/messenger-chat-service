using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.UserIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.SignalR.Hubs.Common;

public class BaseHub(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor context,
    IAppSettings appSettings
    ) : Hub
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly UserIdentity _userIdentity = new(context.HttpContext?.User);
}
