using System.ComponentModel.DataAnnotations;
using Messenger.Domain.Shared.Constants.Validation;

namespace Messenger.WebApi.Controllers.Models.Auth;

public class AuthControllerResetPasswordRequest
{
    [MaxLength(MaxLength.ResetToken)]
    public required string ResetToken { get; set; }

    [MaxLength(MaxLength.Password)]
    public required string Password { get; set; }
}
