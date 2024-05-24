using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Adapters;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Admins;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions;
using MessengerX.Domain.Services;
using MessengerX.Persistence.Extensions;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService;

public class AdminService : BaseService, IAdminService
{
    private readonly AdminBS _adminBS;
    private readonly UserBS _userBS;

    public AdminService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        AdminBS adminBS,
        UserBS userBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _adminBS = adminBS;
        _userBS = userBS;
    }

    public async Task<AdminServiceUsersResponse> UsersAsync(AdminServiceUsersRequest request)
    {
        IEnumerable<User> users = await _userBS.GetUsersAsync();

        PaginatorResponse<User> paginatedData = users
            .OrderBy(user => user.Id)
            .Pagination(request.Pagination);

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
            await _userBS.GetUserByIdAsync(request.Id)
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

    public async Task<AdminServiceBlockUserResponse> BlockUserAsync(
        AdminServiceBlockUserRequest request
    )
    {
        User user =
            await _userBS.GetUserByIdAsync(request.UserId, true)
            ?? throw new NotExistsException("User not found");

        await _userBS.BlockUserAsync(user);

        return new AdminServiceBlockUserResponse() { IsSuccess = true };
    }

    public async Task<AdminServiceUnblockUserResponse> UnblockUserAsync(
        AdminServiceUnblockUserRequest request
    )
    {
        User user =
            await _userBS.GetUserByIdAsync(request.UserId, true)
            ?? throw new NotExistsException("User not found");

        await _userBS.UnblockUserAsync(user);

        return new AdminServiceUnblockUserResponse() { IsSuccess = true };
    }
}
