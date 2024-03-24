using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.Domain.Shared.Constants.Common;
using MessengerX.WebApi.Controllers.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("profile"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> Profile()
    {
        AdminServiceProfileResponse response = await _adminService.GetProfileAsync();

        return Ok(response);
    }

    [HttpGet("users"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> GetUsers([FromQuery] AdminControllerUsersRequest request)
    {
        AdminServiceUsersResponse response = await _adminService.UsersAsync(
            new AdminServiceUsersRequest()
            {
                Pagination = request.Pagination,
                IsLoadImage = request.IsLoadImage
            }
        );

        return Ok(response);
    }

    [HttpGet("users/{id:int}"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> GetUser(
        [FromQuery] AdminControllerUserRequest request,
        [FromRoute] int id
    )
    {
        AdminServiceUserResponse response = await _adminService.UserAsync(
            new AdminServiceUserRequest() { Id = id, IsLoadImage = request.IsLoadImage }
        );

        return Ok(response);
    }

    [HttpPost("block-user"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> BlockUser([FromBody] AdminControllerBlockUserRequest request)
    {
        AdminServiceBlockUserResponse response = await _adminService.BlockUserAsync(
            new AdminServiceBlockUserRequest() { UserId = request.Id }
        );

        return Ok(response);
    }

    [HttpPost("unblock-user"), Authorize(Policy = AuthPolicy.OnlyAdmin)]
    public async Task<IActionResult> UnblockUser([FromBody] AdminControllerBlockUserRequest request)
    {
        AdminServiceUnblockUserResponse response = await _adminService.UnblockUserAsync(
            new AdminServiceUnblockUserRequest() { UserId = request.Id }
        );

        return Ok(response);
    }
}
