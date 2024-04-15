using System.Security.Claims;
using System.Text.Json;
using MessengerX.Application.Services.AuthService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Accounts.RefreshTokens;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Services.AuthService;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.Domain.Shared.Models;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Infrastructure.NotificationTemplates;
using MessengerX.Notifications.Email;
using MessengerX.Notifications.Email.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AuthService;

public class AuthService : BaseService, IAuthService
{
    private readonly IDataProtectionProvider _protection;
    private readonly IEmailClient _emailClient;

    public AuthService(
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

    public async Task<AuthServiceLoginResponse> LoginAsync(AuthServiceLoginRequest request)
    {
        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Email == request.Email)
            ?? throw new InvalidCredentialsException(
                "Invalid credentials",
                ClientMessageSettings.Same
            );

        bool isVerify = AuthBS.VerifyPasswordHash(
            request.Password,
            new Password() { Hash = account.PasswordHash, Salt = account.PasswordSalt }
        );

        if (!isVerify)
            throw new InvalidCredentialsException("Wrong password", ClientMessageSettings.Same);

        if (account is User { IsBanned: true })
            throw new AccessException("Account was banned", ClientMessageSettings.Same);

        string refreshToken = AuthOptions.CreateRefreshToken();
        string accessToken = AuthOptions.CreateAccessToken(
            [
                new(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new(ClaimTypes.Name, account.Login),
                new(ClaimTypes.Email, account.Email),
                new(ClaimTypes.Role, account.Role)
            ],
            new Dictionary<string, string>()
            {
                { TokenClaim.SecretKey, _appSettings.Common.SecretKey },
                { TokenClaim.Audience, _appSettings.Auth.Audience },
                { TokenClaim.Issuer, _appSettings.Auth.Issuer },
                { TokenClaim.AccessTokenLifeTime, _appSettings.Auth.AccessTokenLifeTime },
            }
        );

        double refreshTokenLifeTime = double.Parse(_appSettings.Auth.RefreshTokenLifeTime);

        DateTime expiryTime = DateTime.Now.AddMinutes(refreshTokenLifeTime);

        var newRefreshToken = new RefreshToken(refreshToken, expiryTime, account.Id);

        await _unitOfWork.RefreshToken.AddAsync(newRefreshToken);
        await _unitOfWork.SaveChangesAsync();

        return new AuthServiceLoginResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExp = expiryTime
        };
    }

    public async Task<AuthServiceRefreshTokenResponse> RefreshTokenAsync(
        AuthServiceRefreshTokenRequest request
    )
    {
        RefreshToken refreshToken =
            await _unitOfWork.RefreshToken.GetAsync(token => token.Token == request.RefreshToken)
            ?? throw new InvalidCredentialsException(
                "Invalid refresh token",
                ClientMessageSettings.Same
            );

        if (refreshToken.ExpiryTime < DateTime.Now)
            throw new ExpiredException("Expired refresh token", ClientMessageSettings.Same);

        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Id == refreshToken.AccountId)
            ?? throw new InvalidCredentialsException(
                "Account not exists",
                ClientMessageSettings.Default
            );

        if (account is User { IsBanned: true })
            throw new AccessException("Account was banned", ClientMessageSettings.Same);

        string accessToken = AuthOptions.CreateAccessToken(
            [
                new(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new(ClaimTypes.Name, account.Login),
                new(ClaimTypes.Email, account.Email),
                new(ClaimTypes.Role, account.Role)
            ],
            new Dictionary<string, string>()
            {
                { TokenClaim.SecretKey, _appSettings.Common.SecretKey },
                { TokenClaim.Audience, _appSettings.Auth.Audience },
                { TokenClaim.Issuer, _appSettings.Auth.Issuer },
                { TokenClaim.AccessTokenLifeTime, _appSettings.Auth.AccessTokenLifeTime },
            }
        );

        return new AuthServiceRefreshTokenResponse() { AccessToken = accessToken };
    }

    public async Task<AuthServiceResetTokenResponse> ResetTokenAsync(
        AuthServiceResetTokenRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Email == request.Email)
            ?? throw new NotExistsException("Account not exists");

        string baseUrl = _appSettings.Client.BaseUrl;

        string path = _appSettings.RoutePath.ResetToken;

        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string resetTokenJson = JsonSerializer.Serialize(
            new ResetToken()
            {
                Id = account.Id,
                Email = request.Email,
                ExpirationDate = DateTime.Now.AddHours(1),
            }
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

        return new AuthServiceResetTokenResponse() { IsSuccess = true };
    }

    public async Task<AuthServiceResetPasswordResponse> ResetPasswordAsync(
        AuthServiceResetPasswordRequest request
    )
    {
        string secretKey = _appSettings.Common.SecretKey;

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string resetTokenJson = protector.Unprotect(request.ResetToken);

        ResetToken resetToken =
            JsonSerializer.Deserialize<ResetToken>(resetTokenJson)
            ?? throw new IncorrectDataException("Incorrect reset token");

        if (resetToken.ExpirationDate < DateTime.Now)
            throw new ExpiredException("Reset token has expired");

        Account account =
            await _unitOfWork.Account.GetAsync(account => account.Id == resetToken.Id)
            ?? throw new NotExistsException("Account not exists");

        Password password = AuthBS.CreatePasswordHash(request.Password);

        account.UpdatePassword(password.Hash, password.Salt);

        await _unitOfWork.Account.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();

        return new AuthServiceResetPasswordResponse() { IsSuccess = true };
    }

    public async Task<AuthServiceRevokeTokenResponse> RevokeTokenAsync(
        AuthServiceRevokeTokenRequest request
    )
    {
        RefreshToken refreshToken =
            await _unitOfWork.RefreshToken.GetAsync(token => token.Token == request.RefreshToken)
            ?? throw new InvalidCredentialsException(
                "Invalid refresh token",
                ClientMessageSettings.Same
            );

        if (refreshToken.ExpiryTime < DateTime.Now)
            throw new ExpiredException("Expired refresh token", ClientMessageSettings.Same);

        await _unitOfWork.RefreshToken.DeleteAsync(refreshToken);
        await _unitOfWork.SaveChangesAsync();

        return new AuthServiceRevokeTokenResponse() { IsSuccess = true };
    }
}
