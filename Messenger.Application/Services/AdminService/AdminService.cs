using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Adapters;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.Helpers;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Models;
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
            await _unitOfWork.User.GetAllAsync()
            ?? throw new NotExistsException("Users not exists");

        Pagination? pagination = request.Pagination;

        IOrderedEnumerable<User> sortedUsers = users.OrderBy((user) => user.Id);

        PaginatorResponse<User> paginatedData = sortedUsers.Pagination(pagination);

        IEnumerable<AdminServiceUserResponsePayload> adaptedUsers = paginatedData
            .Collection
            .Select(user => new AdminServiceUserAdapter(user));

        return new AdminServiceUsersResponse() { Meta = paginatedData.Meta, Users = adaptedUsers };
    }

    public async Task<AdminServiceUserResponse> GetUserAsync(AdminServiceUserRequest request)
    {
        User user =
            await _unitOfWork.User.GetAsync((user) => user.Id == request.Id)
            ?? throw new NotExistsException("User not exists");

        return new AdminServiceUserResponse()
        {
            Id = user.Id,
            Login = user.Login,
            Email = user.Email,
            Role = user.Role,
            Image = user.Image,
            Birthday = user.Birthday,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}
