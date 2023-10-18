using MessengerX.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MessengerX.Application.Services.Common;

public interface IBaseService
{
    void SetClaimsPrincipal(ClaimsPrincipal? claimsPrincipal);
}

public abstract class BaseService : IBaseService
{
    protected readonly IUnitOfWork _unitOfWork;
    protected ClaimsPrincipal? _claimsPrincipal;

    public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor context)
    {
        _unitOfWork = unitOfWork;
        _claimsPrincipal = context.HttpContext?.User;
    }

    public void SetClaimsPrincipal(ClaimsPrincipal? claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }
}
