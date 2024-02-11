using MessengerX.Application.Services.AuthService;
using MessengerX.Application.Services.AuthService.Models;
using MessengerX.Application.Services.UserService;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.WebApi.Controllers.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(
        [FromBody] UserControllerRegistrationRequest request
    )
    {
        UserServiceRegistrationResponse response = await _userService.RegistrationAsync(
            new UserServiceRegistrationRequest()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Birthday = request.Birthday,
            }
        );

        return Ok(response);
    }

    [HttpPost("confirmation")]
    public async Task<IActionResult> Confirmation(
        [FromBody] UserControllerConfirmationRequest request
    )
    {
        UserServiceConfirmationResponse confirmResponse = await _userService.ConfirmationAsync(
            new UserServiceConfirmationRequest() { Confirmation = request.Confirmation }
        );

        AuthServiceLoginResponse response = await _authService.LoginAsync(
            new AuthServiceLoginRequest()
            {
                Email = confirmResponse.Email,
                Password = confirmResponse.Password
            }
        );

        return Ok(response);
    }

    [HttpPut("update"), Authorize(Policy = AuthPolicy.OnlyUser)]
    public async Task<IActionResult> UpdateInfo(UserControllerUpdateInfoRequest request)
    {
        UserServiceUpdateResponse response = await _userService.UpdateAsync(
            new UserServiceUpdateRequest() { Login = request.Login, Birthday = request.Birthday }
        );

        return Ok(response);
    }

    [HttpGet("profile"), Authorize(Policy = AuthPolicy.OnlyUser)]
    public async Task<IActionResult> Profile()
    {
        UserServiceProfileResponse response = await _userService.GetProfileAsync();

        return Ok(response);
    }
}
