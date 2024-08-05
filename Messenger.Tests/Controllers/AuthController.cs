using Messenger.Application.Services.AuthService;
using Messenger.WebApi.Controllers;
using Messenger.WebApi.Controllers.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Tests.Controllers;

public class AuthControllerTest
{
    private readonly AuthController _authController;
    private readonly Mock<IAuthService> _authService;

    public AuthControllerTest()
    {
        _authService = new Mock<IAuthService>();
        _authController = new AuthController(_authService.Object);
    }

    [Fact]
    public async Task Login()
    {
        // Arrange
        var loginRequest = new AuthControllerLoginRequest
        {
            Email = "admin@admin.com",
            Password = "Sosnova61S"
        };

        // Act
        IActionResult response = await _authController.Login(loginRequest);

        // Assert
        Assert.IsType<OkObjectResult>(response);
        Assert.NotNull(response);
    }

    [Fact]
    public async Task ResetToken()
    {
        // Arrange
        var resetTokenRequest = new AuthControllerResetTokenRequest { Email = "admin@admin.com" };

        // Act
        IActionResult response = await _authController.ResetToken(resetTokenRequest);

        // Assert
        Assert.IsType<OkObjectResult>(response);
        Assert.NotNull(response);
    }
}
