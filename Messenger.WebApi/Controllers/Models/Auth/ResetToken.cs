using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Auth;

public class AuthControllerResetTokenRequest
{
    [EmailAddress, MaxLength(MaxLength.Email)]
    public required string Email { get; set; }
}
