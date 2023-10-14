using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService;
using MessengerX.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services;

public class UserService : BaseService, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor context)
        : base(unitOfWork, context) { }
}
