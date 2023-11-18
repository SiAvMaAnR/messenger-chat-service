using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;

namespace MessengerX.Application.Services.UserService;

public interface IUserService : IBaseService
{
    Task<UserServiceRegistrationResponse> RegistrationAsync(UserServiceRegistrationRequest request);
    Task<UserServiceConfirmationResponse> ConfirmationAsync(UserServiceConfirmationRequest request);
    Task<UserServiceProfileResponse> GetProfileAsync(UserServiceProfileRequest request);
}
