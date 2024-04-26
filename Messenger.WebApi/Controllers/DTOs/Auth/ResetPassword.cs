using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Auth;

public class AuthControllerResetPasswordRequest
{
    [MaxLength(MaxLength.ResetToken)]
    public string ResetToken { get; set; } = null!;

    [MaxLength(MaxLength.Password)]
    public string Password { get; set; } = null!;
}
