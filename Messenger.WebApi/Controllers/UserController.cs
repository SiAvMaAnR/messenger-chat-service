using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.AccountService.Models;
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
    private readonly IAccountService _accountService;

    public UserController(IUserService userService, IAccountService accountService)
    {
        _userService = userService;
        _accountService = accountService;
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

        return Ok(new { response.IsSuccess });
    }

    [HttpPost("confirmation")]
    public async Task<IActionResult> Confirmation(
        [FromBody] UserControllerConfirmationRequest request
    )
    {
        UserServiceConfirmationResponse confirmResponse = await _userService.ConfirmationAsync(
            new UserServiceConfirmationRequest() { Confirmation = request.Confirmation }
        );

        AccountServiceLoginResponse loginResponse = await _accountService.LoginAsync(
            new AccountServiceLoginRequest()
            {
                Email = confirmResponse.Email,
                Password = confirmResponse.Password
            }
        );

        return Ok(new { loginResponse.TokenType, loginResponse.Token });
    }

    [HttpGet("profile"), Authorize(Policy = AuthPolicy.OnlyUser)]
    public async Task<IActionResult> Profile()
    {
        UserServiceProfileResponse response = await _userService.GetProfileAsync();

        return Ok(
            new
            {
                response.Login,
                response.Email,
                response.Role,
                response.Birthday
            }
        );
    }

    [HttpGet("image"), Authorize(Policy = AuthPolicy.OnlyUser)]
    public async Task<IActionResult> Image()
    {
        UserServiceImageResponse response = await _userService.GetImageAsync();

        return Ok(new { response.Image });
    }

    [HttpPost("upload-image"), Authorize(Policy = AuthPolicy.OnlyUser)]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        UserServiceUploadImageResponse response = await _userService.UploadImageAsync(
            new UserServiceUploadImageRequest() { File = file }
        );

        return Ok(new { response.IsSuccess });
    }
}
