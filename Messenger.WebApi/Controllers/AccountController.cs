using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.WebApi.Controllers.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        AccountServiceLoginResponse response = await _accountService.LoginAsync(
            new AccountServiceLoginRequest() { Email = request.Email, Password = request.Password }
        );

        return Ok(response);
    }

    [HttpPost("reset-token")]
    public async Task<IActionResult> ResetToken([FromBody] ResetTokenRequest request)
    {
        AccountServiceResetTokenResponse response = await _accountService.ResetTokenAsync(
            new AccountServiceResetTokenRequest() { Email = request.Email }
        );

        return Ok(response);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        AccountServiceResetPasswordResponse response = await _accountService.ResetPasswordAsync(
            new AccountServiceResetPasswordRequest()
            {
                ResetToken = request.ResetToken,
                Password = request.Password
            }
        );

        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        AccountServiceRefreshTokenResponse response = await _accountService.RefreshTokenAsync(
            new AccountServiceRefreshTokenRequest() { RefreshToken = request.RefreshToken }
        );

        return Ok(response);
    }


    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest request)
    {
        AccountServiceRevokeTokenResponse response = await _accountService.RevokeTokenAsync(
            new AccountServiceRevokeTokenRequest() { RefreshToken = request.RefreshToken }
        );

        return Ok(response);
    }
}
