using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Domain.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using System.Text.Json;
using MessengerX.Notifications.Common;
using MessengerX.Notifications.Email.Models;
using MessengerX.Notifications;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.NotificationTemplates;
using MessengerX.Domain.Exceptions.Common;

namespace MessengerX.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    private readonly IDataProtectionProvider _protection;
    private readonly INotificationClient _emailClient;
    private readonly IAppSettings _appSettings;

    public AccountService(
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

    public async Task<LoginAccountResponse> LoginAsync(LoginAccountRequest request)
    {
        var account =
            await _unitOfWork.Account.GetAsync(account => account.Email == request.Email)
            ?? throw new NotExistsException("Account not exists");

        bool isVerify = PasswordOptions.VerifyPasswordHash(
            request.Password,
            new Password() { Hash = account.PasswordHash, Salt = account.PasswordSalt }
        );

        if (!isVerify)
            throw new InvalidCredentialsException("Wrong password", ClientMessageSettings.Same);

        string token = TokenOptions.CreateToken(
            new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new(ClaimTypes.Name, account.Login),
                new(ClaimTypes.Email, account.Email),
                new(ClaimTypes.Role, account.Role.ToString())
            },
            new Dictionary<string, string>()
            {
                { "secretKey", _appSettings.Common.SecretKey },
                { "audience", _appSettings.Auth.Audience },
                { "issuer", _appSettings.Auth.Issuer },
                { "lifeTime", _appSettings.Auth.LifeTime },
            }
        );

        return new LoginAccountResponse() { TokenType = "Bearer", Token = token };
    }

    public Task<GetAllAccountsResponse> GetAllAsync(GetAllAccountsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ResetTokenAccountResponse> ResetTokenAsync(ResetTokenAccountRequest request)
    {
        var account =
            await _unitOfWork.Account.GetAsync(account => account.Email == request.Email)
            ?? throw new NotExistsException("Account not exists");

        string baseUrl = _appSettings.Client.BaseUrl;

        string path = _appSettings.Path.ResetToken;

        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string resetTokenJson = JsonSerializer.Serialize(
            new ResetToken() { Id = account.Id, Email = request.Email, }
        );

        string resetToken = protector.Protect(resetTokenJson);

        string resetPasswordLink = $"{baseUrl}/{path}?token={resetToken}";

        string smtpEmail = _appSettings.Smtp.Email;

        EmailTemplate template = NotificationTemplate.ResetToken(resetPasswordLink);

        var message = new Message()
        {
            From = new Address(baseUrl, smtpEmail),
            To = new Address(account.Login, account.Email),
            Subject = template.Subject,
            Content = template.Content
        };

        await _emailClient.SendAsync(message);

        return new ResetTokenAccountResponse() { IsSuccess = true };
    }

    public Task<ResetPasswordAccountResponse> ResetPasswordAsync(
        ResetPasswordAccountRequest request
    )
    {
        throw new NotImplementedException();
    }
}
