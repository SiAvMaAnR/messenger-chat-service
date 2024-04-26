using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Auth;

public class AuthControllerLoginRequest
{
    [EmailAddress, MaxLength(MaxLength.Email)]
    public string Email { get; set; } = null!;

    [MaxLength(MaxLength.Password)]
    public string Password { get; set; } = null!;
}
