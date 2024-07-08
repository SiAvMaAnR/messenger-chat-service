using MessengerX.Application.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.Common;

public interface IBaseService { }

public abstract class BaseService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor context,
    IAppSettings appSettings
) : IBaseService
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IAppSettings _appSettings = appSettings;
    protected readonly UserIdentity _userIdentity = new(context.HttpContext?.User);
    protected int UserId =>
        _userIdentity.Id ?? throw new OperationNotAllowedException("Failed to get user id");
}
