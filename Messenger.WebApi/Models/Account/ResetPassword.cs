using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Account;

public class ResetPasswordRequest
{
    [MaxLength(MaxLength.ResetToken)]
    public string ResetToken { get; set; } = null!;

    [MaxLength(MaxLength.Password)]
    public string Password { get; set; } = null!;
}
