using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Adapters;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Persistence.Extensions;
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

    public async Task<AdminServiceUsersResponse> UsersAsync(AdminServiceUsersRequest request)
    {
        IEnumerable<User> users =
            await _unitOfWork.User.GetAllAsync()
            ?? throw new NotExistsException("Users not exists");

        IOrderedEnumerable<User> sortedUsers = users.OrderBy(user => user.Id);

        PaginatorResponse<User> paginatedData = sortedUsers.Pagination(request.Pagination);

        var adaptedUsers = paginatedData
            .Collection
            .Select(user => new AdminServiceUserAdapter(user))
            .ToList();

        if (request.IsLoadImage)
            await Task.WhenAll(adaptedUsers.Select(user => user.LoadImageAsync()));

        return new AdminServiceUsersResponse() { Meta = paginatedData.Meta, Users = adaptedUsers };
    }

    public async Task<AdminServiceUserResponse> UserAsync(AdminServiceUserRequest request)
    {
        User user =
            await _unitOfWork.User.GetAsync(user => user.Id == request.Id)
            ?? throw new NotExistsException("User not exists");

        byte[]? image = request.IsLoadImage ? await FileManager.ReadToBytesAsync(user.Image) : null;

        return new AdminServiceUserResponse()
        {
            Id = user.Id,
            Login = user.Login,
            Email = user.Email,
            Role = user.Role,
            Image = image,
            Birthday = user.Birthday,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    public async Task<AdminServiceProfileResponse> GetProfileAsync()
    {
        Admin admin =
            await _unitOfWork.Admin.GetAsync(admin => admin.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Admin not found");

        return new AdminServiceProfileResponse()
        {
            Login = admin.Login,
            Email = admin.Email,
            Role = admin.Role,
        };
    }

    public async Task<AdminServiceBlockUserResponse> BlockUserAsync(
        AdminServiceBlockUserRequest request
    )
    {
        User user =
            await _unitOfWork.User.GetAsync(user => user.Id == request.UserId)
            ?? throw new NotExistsException("User not found");

        user.UpdateIsBanned(true);
        await _unitOfWork.SaveChangesAsync();

        return new AdminServiceBlockUserResponse() { IsSuccess = true };
    }

    public async Task<AdminServiceUnblockUserResponse> UnblockUserAsync(
        AdminServiceUnblockUserRequest request
    )
    {
        User user =
            await _unitOfWork.User.GetAsync(user => user.Id == request.UserId)
            ?? throw new NotExistsException("User not found");

        user.UpdateIsBanned(false);
        await _unitOfWork.SaveChangesAsync();

        return new AdminServiceUnblockUserResponse() { IsSuccess = true };
    }
}
