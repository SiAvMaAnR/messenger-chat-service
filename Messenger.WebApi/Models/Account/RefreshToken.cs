using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Account;

public class RefreshTokenRequest
{
    [MaxLength(MaxLength.RefreshToken)]
    public string RefreshToken { get; set; } = null!;
}
