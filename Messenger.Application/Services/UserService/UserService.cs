using System.Text.Json;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Infrastructure.NotificationTemplates;
using MessengerX.Notifications;
using MessengerX.Notifications.Common;
using MessengerX.Notifications.Email.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MessengerX.Application.Services.UserService;

public class UserService : BaseService, IUserService
{
    private readonly IDataProtectionProvider _protection;
    private readonly INotificationClient _emailClient;
    private readonly IAppSettings _appSettings;

    public UserService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IConfiguration configuration,
        IDataProtectionProvider protection,
        IAppSettings appSettings,
        EmailClient emailClient
    )
        : base(unitOfWork, context, configuration)
    {
        _protection = protection;
        _appSettings = appSettings;
        _emailClient = emailClient;
    }

    public async Task<RegistrationUserResponse> RegistrationAsync(RegistrationUserRequest request)
    {
        if (await _unitOfWork.User.AnyAsync(user => user.Email == request.Email))
            throw new AlreadyExistsException("Account already exists");

        string baseUrl = _appSettings.Client.BaseUrl;

        string path = _appSettings.Path.Registration;

        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string confirmationJson = JsonSerializer.Serialize(
            new Confirmation()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Birthday = request.Birthday
            }
        );

        string confirmation = protector.Protect(confirmationJson);

        string confirmationLink = $"{baseUrl}/{path}?code={confirmation}";

        string smtpEmail = _appSettings.Smtp.Email;

        EmailTemplate template = NotificationTemplate.Registration(confirmationLink);

        var message = new Message()
        {
            From = new Address(baseUrl, smtpEmail),
            To = new Address(request.Login, request.Email),
            Subject = template.Subject,
            Content = template.Content
        };

        await _emailClient.SendAsync(message);

        return new RegistrationUserResponse() { IsSuccess = true };
    }

    public async Task<ConfirmationUserResponse> ConfirmationAsync(ConfirmationUserRequest request)
    {
        var secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);
        string confirmationJson = protector.Unprotect(request.Confirmation);

        Confirmation confirmation =
            JsonSerializer.Deserialize<Confirmation>(confirmationJson)
            ?? throw new InvalidConfirmationException(
                "Invalid confirmation"
            );

        if (await _unitOfWork.Account.AnyAsync(account => account.Email == confirmation.Email))
            throw new AlreadyExistsException("Account already exists");

        var password = PasswordOptions.CreatePasswordHash(confirmation.Password);

        var user = new User()
        {
            Login = confirmation.Login,
            Email = confirmation.Email,
            PasswordHash = password.Hash,
            PasswordSalt = password.Salt,
            Birthday = confirmation.Birthday,
        };

        await _unitOfWork.User.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return new ConfirmationUserResponse()
        {
            Email = confirmation.Email,
            Password = confirmation.Password
        };
    }

    public Task<GetAllUsersResponse> GetAllAsync(GetAllUsersRequest request)
    {
        throw new NotImplementedException();
    }
}
