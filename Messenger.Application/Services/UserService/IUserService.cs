using Messenger.Application.Services.Common;
using Messenger.Application.Services.UserService.Models;

namespace Messenger.Application.Services.UserService;

public interface IUserService : IBaseService
{
    Task<UserServiceRegistrationResponse> RegistrationAsync(UserServiceRegistrationRequest request);
    Task<UserServiceConfirmationResponse> ConfirmationAsync(UserServiceConfirmationRequest request);
    Task<UserServiceUpdateResponse> UpdateAsync(UserServiceUpdateRequest request);
    Task<UserServiceUsersResponse> UsersAsync(UserServiceUsersRequest request);
    Task<UserServiceUserResponse> UserAsync(UserServiceUserRequest request);
    Task<UserServiceBlockUserResponse> BlockUserAsync(UserServiceBlockUserRequest request);
    Task<UserServiceUnblockUserResponse> UnblockUserAsync(UserServiceUnblockUserRequest request);
}
