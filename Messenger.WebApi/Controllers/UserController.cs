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

    [HttpPost("Registration")]
    public async Task<IActionResult> Registration([FromBody] RegistrationUser request)
    {
        var response = await _userService.RegistrationAsync(
            new RegistrationUserRequest()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Description = request.Description,
            }
        );

        return Ok(new { response.IsSuccess });
    }

    [HttpPost("Confirm")]
    public async Task<IActionResult> Confirmation([FromBody] ConfirmationUser request)
    {
        var confirmResponse = await _userService.ConfirmUserAsync(
            new ConfirmUserRequest() { Confirmation = request.Confirmation }
        );

        var loginResponse = await _accountService.LoginAsync(
            new LoginUserRequest()
            {
                Email = confirmResponse.Email,
                Password = confirmResponse.Password
            }
        );

        return Ok(
            new
            {
                loginResponse.IsSuccess,
                loginResponse.TokenType,
                loginResponse.Token
            }
        );
    }
}
