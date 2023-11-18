using System.Security.Claims;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.Common;

public interface IBaseService
{
    void SetClaimsPrincipal(ClaimsPrincipal? claimsPrincipal);
}

public abstract class BaseService : IBaseService
{
    protected readonly IUnitOfWork _unitOfWork;
    protected ClaimsPrincipal? _claimsPrincipal;
    protected readonly IAppSettings _appSettings;

    public BaseService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings
    )
    {
        _unitOfWork = unitOfWork;
        _claimsPrincipal = context.HttpContext?.User;
        _appSettings = appSettings;
    }

    public void SetClaimsPrincipal(ClaimsPrincipal? claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }
}
