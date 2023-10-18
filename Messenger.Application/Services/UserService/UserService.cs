using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService;

public class UserService : BaseService, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor context)
        : base(unitOfWork, context) { }

    public Task<GetAllUsersResponse> GetAllAsync(GetAllUsersRequest request)
    {
        throw new NotImplementedException();
    }
}
