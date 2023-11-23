using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.UserIdentity;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.Common;

public interface IBaseService { }

public abstract class BaseService : IBaseService
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IAppSettings _appSettings;
    protected readonly UserIdentity _userIdentity;

    public BaseService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings
    )
    {
        _unitOfWork = unitOfWork;
        _appSettings = appSettings;
        _userIdentity = new UserIdentity(context.HttpContext?.User);
    }
}
