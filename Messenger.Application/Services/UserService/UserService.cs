using System.Text.Json;
using Messenger.Application.Services.Common;
using Messenger.Application.Services.UserService.Adapters;
using Messenger.Application.Services.UserService.Models;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Users;
using Messenger.Domain.Exceptions;
using Messenger.Domain.Services;
using Messenger.Domain.Shared.Models;
using Messenger.Notifications.Common;
using Messenger.Notifications.Email;
using Messenger.Notifications.Email.Models;
using Messenger.Notifications.NotificationTemplates;
using Messenger.Persistence.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.UserService;

public class UserService : BaseService, IUserService
{
    private readonly IDataProtectionProvider _protection;
    private readonly IEmailClient _emailClient;
    private readonly UserBS _userBS;

    public UserService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        IDataProtectionProvider protection,
        IEmailClient emailClient,
        UserBS userBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _protection = protection;
        _emailClient = emailClient;
        _userBS = userBS;
    }

    public async Task<UserServiceRegistrationResponse> RegistrationAsync(
        UserServiceRegistrationRequest request
    )
    {
        await _userBS.CheckExistenceByEmailAsync(request.Email);

        string baseUrl = _appSettings.Client.BaseUrl;

        string path = _appSettings.RoutePath.ConfirmRegistration;

        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string confirmationJson = JsonSerializer.Serialize(
            new Confirmation()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Birthday = request.Birthday,
                ExpirationDate = DateTime.Now.AddHours(1)
            }
        );

        string confirmation = protector.Protect(confirmationJson);

        string confirmationLink = $"{baseUrl}/{path}?code={confirmation}";

        string smtpEmail = _appSettings.Smtp.Email;

        EmailTemplate template = NotificationTemplate.Registration(confirmationLink);

        var message = new EmailMessage()
        {
            From = new EmailAddress(baseUrl, smtpEmail),
            To = new EmailAddress(request.Login, request.Email),
            Subject = template.Subject,
            Content = template.Content
        };

        await _emailClient.SendAsync(message);

        return new UserServiceRegistrationResponse() { IsSuccess = true };
    }

    public async Task<UserServiceConfirmationResponse> ConfirmationAsync(
        UserServiceConfirmationRequest request
    )
    {
        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);
        string confirmationJson = protector.Unprotect(request.Confirmation);

        Confirmation confirmation =
            JsonSerializer.Deserialize<Confirmation>(confirmationJson)
            ?? throw new InvalidConfirmationException();

        await _userBS.ConfirmRegistrationAsync(confirmation);

        return new UserServiceConfirmationResponse()
        {
            Email = confirmation.Email,
            Password = confirmation.Password
        };
    }

    public async Task<UserServiceUpdateResponse> UpdateAsync(UserServiceUpdateRequest request)
    {
        User user =
            await _userBS.GetUserByIdAsync(UserId)
            ?? throw new NotExistsException("User not found");

        await _userBS.UpdateAsync(user, request.Login, request.Birthday);

        return new UserServiceUpdateResponse() { IsSuccess = true };
    }

    public async Task<UserServiceUsersResponse> UsersAsync(UserServiceUsersRequest request)
    {
        IEnumerable<User> users = await _userBS.GetUsersAsync();

        PaginatorResponse<User> paginatedData = users.Pagination(request.Pagination);

        var adaptedUsers = paginatedData
            .Collection
            .Select(user => new UserServiceUserAdapter(user))
            .ToList();

        if (request.IsLoadImage)
            await Task.WhenAll(adaptedUsers.Select(user => user.LoadImageAsync()));

        return new UserServiceUsersResponse() { Meta = paginatedData.Meta, Users = adaptedUsers };
    }

    public async Task<UserServiceUserResponse> UserAsync(UserServiceUserRequest request)
    {
        User user =
            await _userBS.GetUserByIdAsync(request.Id)
            ?? throw new NotExistsException("User not exists");

        byte[]? image = request.IsLoadImage ? await FileManager.ReadToBytesAsync(user.Image) : null;

        return new UserServiceUserResponse()
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

    public async Task<UserServiceBlockUserResponse> BlockUserAsync(
        UserServiceBlockUserRequest request
    )
    {
        User user =
            await _userBS.GetUserByIdAsync(request.UserId, true)
            ?? throw new NotExistsException("User not found");

        await _userBS.BlockUserAsync(user);

        return new UserServiceBlockUserResponse() { IsSuccess = true };
    }

    public async Task<UserServiceUnblockUserResponse> UnblockUserAsync(
        UserServiceUnblockUserRequest request
    )
    {
        User user =
            await _userBS.GetUserByIdAsync(request.UserId, true)
            ?? throw new NotExistsException("User not found");

        await _userBS.UnblockUserAsync(user);

        return new UserServiceUnblockUserResponse() { IsSuccess = true };
    }
}
