using MessengerX.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
    protected readonly IConfiguration _configuration;

    public BaseService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IConfiguration configuration
    )
    {
        _unitOfWork = unitOfWork;
        _claimsPrincipal = context.HttpContext?.User;
        _configuration = configuration;
    }

    public void SetClaimsPrincipal(ClaimsPrincipal? claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }
}
