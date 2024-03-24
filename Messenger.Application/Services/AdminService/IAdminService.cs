using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Application.Services.Common;

namespace MessengerX.Application.Services.AdminService;

public interface IAdminService : IBaseService
{
    Task<AdminServiceUsersResponse> UsersAsync(AdminServiceUsersRequest request);
    Task<AdminServiceUserResponse> UserAsync(AdminServiceUserRequest request);
    Task<AdminServiceBlockUserResponse> BlockUserAsync(AdminServiceBlockUserRequest request);
    Task<AdminServiceUnblockUserResponse> UnblockUserAsync(AdminServiceUnblockUserRequest request);
    Task<AdminServiceProfileResponse> GetProfileAsync();
}
