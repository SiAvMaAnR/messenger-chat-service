using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService;

public class AdminService : BaseService, IAdminService
{
    public AdminService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings
    )
        : base(unitOfWork, context, appSettings) { }

    public async Task<AdminServiceUsersResponse> GetUsersAsync(AdminServiceUsersRequest request)
    {
        IEnumerable<User> users =
            await _unitOfWork.User.GetAllAsync() ?? throw new NotExistsException("Users not found");

        throw new NotImplementedException();
    }
}
