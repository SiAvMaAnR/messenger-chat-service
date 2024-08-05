using Messenger.Application.Services.AuthService.Models;
using Messenger.Application.Services.Common;

namespace Messenger.Application.Services.AuthService;

public interface IAuthService : IBaseService
{
    Task<AuthServiceLoginResponse> LoginAsync(AuthServiceLoginRequest request);
    Task<AuthServiceResetTokenResponse> ResetTokenAsync(AuthServiceResetTokenRequest request);
    Task<AuthServiceResetPasswordResponse> ResetPasswordAsync(
        AuthServiceResetPasswordRequest request
    );
    Task<AuthServiceRefreshTokenResponse> RefreshTokenAsync(AuthServiceRefreshTokenRequest request);
    Task<AuthServiceRevokeTokenResponse> RevokeTokenAsync(AuthServiceRevokeTokenRequest request);
}
