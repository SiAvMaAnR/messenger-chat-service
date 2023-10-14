using MessengerX.Application.Services.Common;

namespace MessengerX.Application.Services.UserService;

public interface IUserService : IBaseService
{
    Task<UserGetAllResponse> GetAllAsync(UserGetAllRequest request);
}
