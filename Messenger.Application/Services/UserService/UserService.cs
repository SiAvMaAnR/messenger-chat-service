using System.Text.Json;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Infrastructure.NotificationTemplates;
using MessengerX.Notifications.Email;
using MessengerX.Notifications.Email.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService;

public class UserService : BaseService, IUserService
{
    private readonly IDataProtectionProvider _protection;
    private readonly IEmailClient _emailClient;

    public UserService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        IDataProtectionProvider protection,
        IEmailClient emailClient
    )
        : base(unitOfWork, context, appSettings)
    {
        _protection = protection;
        _emailClient = emailClient;
    }

    public async Task<UserServiceRegistrationResponse> RegistrationAsync(
        UserServiceRegistrationRequest request
    )
    {
        if (await _unitOfWork.Account.AnyAsync(account => account.Email == request.Email))
            throw new AlreadyExistsException(
                "Account already exists",
                "Account with this email already exists"
            );

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

        var message = new Message()
        {
            From = new Address(baseUrl, smtpEmail),
            To = new Address(request.Login, request.Email),
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
            ?? throw new InvalidConfirmationException("Invalid confirmation");

        if (confirmation.ExpirationDate < DateTime.Now)
            throw new ExpiredException("Confirmation has expired", ClientMessageSettings.Same);

        if (await _unitOfWork.Account.AnyAsync(account => account.Email == confirmation.Email))
            throw new AlreadyExistsException("Account already exists", ClientMessageSettings.Same);

        Password password = PasswordOptions.CreatePasswordHash(confirmation.Password);

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

        return new UserServiceConfirmationResponse()
        {
            Email = confirmation.Email,
            Password = confirmation.Password
        };
    }

    public async Task<UserServiceProfileResponse> GetProfileAsync()
    {
        User user =
            await _unitOfWork.User.GetAsync(user => user.Id == _userIdentity.Id)
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
            await _unitOfWork.User.GetAsync(user => user.Id == _userIdentity.Id)
            ?? throw new NotExistsException("User not found");

        user.Login = request.Login;
        user.Birthday = request.Birthday;

        await _unitOfWork.User.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new UserServiceUpdateResponse() { IsSuccess = true };
    }
}
