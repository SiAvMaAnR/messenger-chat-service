using Microsoft.AspNetCore.Mvc;

namespace MessengerX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginAccount request)
    {
        var response = await this.accountService.LoginAsync(
            new LoginAccountRequest() { Email = request.Email, Password = request.Password }
        );

        return Ok(
            new
            {
                response.IsSuccess,
                response.TokenType,
                response.Token
            }
        );
    }
}
