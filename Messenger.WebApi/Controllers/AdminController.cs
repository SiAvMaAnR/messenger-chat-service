using MessengerX.Application.Services.AccountService;
using MessengerX.Application.Services.AdminService;
using MessengerX.Application.Services.AdminService.Models;
using MessengerX.WebApi.Controllers.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly IAccountService _accountService;

    public AdminController(IAdminService adminService, IAccountService accountService)
    {
        _adminService = adminService;
        _accountService = accountService;
    }

    [HttpGet("users"), Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetUsers([FromQuery] AdminControllerUsersRequest request)
    {
        AdminServiceUsersResponse response = await _adminService.GetUsersAsync(
            new AdminServiceUsersRequest() { Pagination = request.Pagination }
        );

        return Ok(new { response });
    }

    [HttpGet("users/{id:int}"), Authorize(Policy = "OnlyAdmin")]
    public async Task<IActionResult> GetUser([FromRoute] AdminControllerUserRequest request)
    {
        AdminServiceUserResponse response = await _adminService.GetUserAsync(
            new AdminServiceUserRequest() { Id = request.Id }
        );

        return Ok(new { response });
    }
}
