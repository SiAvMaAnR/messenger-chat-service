using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.User;

public class RegistrationRequest
{
    [MaxLength(MaxLength.Login)]
    public string Login { get; set; } = null!;

    [EmailAddress, MaxLength(MaxLength.Email)]
    public string Email { get; set; } = null!;

    [MaxLength(MaxLength.Password)]
    public string Password { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
}
