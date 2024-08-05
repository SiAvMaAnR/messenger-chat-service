using System.ComponentModel.DataAnnotations;
using Messenger.Domain.Shared.Constants.Validation;

namespace Messenger.WebApi.Controllers.Models.Auth;

public class AuthControllerRefreshTokenRequest
{
    [MaxLength(MaxLength.RefreshToken)]
    public required string RefreshToken { get; set; }
}
