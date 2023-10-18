using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;

namespace MessengerX.Application.Services.UserService;

public interface IUserService : IBaseService
{
    Task<GetAllUsersResponse> GetAllAsync(GetAllUsersRequest request);
}
