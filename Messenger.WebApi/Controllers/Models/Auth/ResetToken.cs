using System.ComponentModel.DataAnnotations;
using Messenger.Domain.Shared.Constants.Validation;

namespace Messenger.WebApi.Controllers.Models.Auth;

public class AuthControllerResetTokenRequest
{
    [EmailAddress, MaxLength(MaxLength.Email)]
    public required string Email { get; set; }
}
