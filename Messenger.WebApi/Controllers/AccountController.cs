using Messenger.Application.Services.AccountService;
using Messenger.Application.Services.AccountService.Models;
using Messenger.WebApi.Controllers.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("image"), Authorize]
    public async Task<IActionResult> Image()
    {
        AccountServiceImageResponse response = await _accountService.GetImageAsync();

        return Ok(response);
    }

    [HttpPost("upload-image"), Authorize]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        AccountServiceUploadImageResponse response = await _accountService.UploadImageAsync(
            new AccountServiceUploadImageRequest() { File = file }
        );

        return Ok(response);
    }

    [HttpGet("accounts/{id:int}/image"), Authorize]
    public async Task<IActionResult> GetAccountImage([FromRoute] int id)
    {
        AccountServiceAccountImageResponse response = await _accountService.GetAccountImageAsync(
            new AccountServiceAccountImageRequest() { Id = id }
        );

        return Ok(response);
    }

    [HttpGet("accounts"), Authorize]
    public async Task<IActionResult> GetAccounts(
        [FromQuery] AccountControllerAccountsRequest request
    )
    {
        AccountServiceAccountsResponse response = await _accountService.AccountsAsync(
            new AccountServiceAccountsRequest()
            {
                Pagination = request.Pagination,
                IsLoadImage = request.IsLoadImage,
                SearchField = request.SearchField
            }
        );

        return Ok(response);
    }

    [HttpGet("profile"), Authorize]
    public async Task<IActionResult> Profile()
    {
        AccountServiceProfileResponse response = await _accountService.GetProfileAsync();

        return Ok(response);
    }
}
