using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Application.Services.UserService;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.WebApi.Controllers.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAccountService _accountService;

    public UserController(IUserService userService, IAccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
    {
        var response = await _userService.RegistrationAsync(
            new RegistrationUserRequest()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
            }
        );

        return Ok(new { response.IsSuccess });
    }

    [HttpPost("confirmation")]
    public async Task<IActionResult> Confirmation([FromBody] ConfirmationRequest request)
    {
        var confirmResponse = await _userService.ConfirmationAsync(
            new ConfirmationUserRequest() { Confirmation = request.Confirmation }
        );

        var loginResponse = await _accountService.LoginAsync(
            new LoginAccountRequest()
            {
                Email = confirmResponse.Email,
                Password = confirmResponse.Password
            }
        );

        return Ok(new { loginResponse.TokenType, loginResponse.Token });
    }
}
