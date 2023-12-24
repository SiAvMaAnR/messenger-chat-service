using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.Account;

public class RevokeTokenRequest
{
    [MaxLength(MaxLength.RefreshToken)]
    public string RefreshToken { get; set; } = null!;
}
