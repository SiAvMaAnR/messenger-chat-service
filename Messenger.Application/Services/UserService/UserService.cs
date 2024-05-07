using System.Text.Json;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions;
using MessengerX.Domain.Services;
using MessengerX.Domain.Shared.Models;
using MessengerX.Notifications.Common;
using MessengerX.Notifications.Email;
using MessengerX.Notifications.Email.Models;
using MessengerX.Notifications.NotificationTemplates;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService;

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

    public async Task<UserServiceProfileResponse> GetProfileAsync()
    {
        User user =
            await _userBS.GetUserByIdAsync(_userIdentity.Id)
            ?? throw new NotExistsException("User not found");

        return new UserServiceProfileResponse()
        {
            Login = user.Login,
            Email = user.Email,
            Role = user.Role,
            Birthday = user.Birthday
        };
    }

    public async Task<UserServiceUpdateResponse> UpdateAsync(UserServiceUpdateRequest request)
    {
        User user =
            await _userBS.GetUserByIdAsync(_userIdentity.Id)
            ?? throw new NotExistsException("User not found");

        await _userBS.UpdateAsync(user, request.Login, request.Birthday);

        return new UserServiceUpdateResponse() { IsSuccess = true };
    }
}
