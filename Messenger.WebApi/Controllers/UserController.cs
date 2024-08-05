using Messenger.Application.Services.AuthService;
using Messenger.Application.Services.AuthService.Models;
using Messenger.Application.Services.UserService;
using Messenger.Application.Services.UserService.Models;
using Messenger.Domain.Shared.Constants.Common;
using Messenger.WebApi.Controllers.Models.Admin;
using Messenger.WebApi.Controllers.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebApi.Controllers;

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

    [HttpGet("users"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> GetUsers([FromQuery] UserControllerUsersRequest request)
    {
        UserServiceUsersResponse response = await _userService.UsersAsync(
            new UserServiceUsersRequest()
            {
                Pagination = request.Pagination,
                IsLoadImage = request.IsLoadImage
            }
        );

        return Ok(response);
    }

    [HttpGet("users/{id:int}"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> GetUser(
        [FromQuery] UserControllerUserRequest request,
        [FromRoute] int id
    )
    {
        UserServiceUserResponse response = await _userService.UserAsync(
            new UserServiceUserRequest() { Id = id, IsLoadImage = request.IsLoadImage }
        );

        return Ok(response);
    }

    [HttpPost("block-user"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> BlockUser([FromBody] UserControllerBlockUserRequest request)
    {
        UserServiceBlockUserResponse response = await _userService.BlockUserAsync(
            new UserServiceBlockUserRequest() { UserId = request.Id }
        );

        return Ok(response);
    }

    [HttpPost("unblock-user"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> UnblockUser([FromBody] UserControllerBlockUserRequest request)
    {
        UserServiceUnblockUserResponse response = await _userService.UnblockUserAsync(
            new UserServiceUnblockUserRequest() { UserId = request.Id }
        );

        return Ok(response);
    }
}
