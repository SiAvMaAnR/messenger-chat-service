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

        return Ok(new { response.TokenType, response.Token, });
    }

    [HttpPost("reset-token")]
    public async Task<IActionResult> ResetToken([FromBody] ResetTokenRequest request)
    {
        AccountServiceResetTokenResponse response = await _accountService.ResetTokenAsync(
            new AccountServiceResetTokenRequest() { Email = request.Email }
        );

        return Ok(new { response.IsSuccess });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        AccountServiceResetPasswordResponse response = await _accountService.ResetPasswordAsync(
            new AccountServiceResetPasswordRequest() { ResetToken = request.ResetToken }
        );

        return Ok(new { response.IsSuccess });
    }
}
