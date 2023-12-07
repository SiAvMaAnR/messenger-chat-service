using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.User;

public class UserControllerUpdateInfoRequest
{
    [MaxLength(MaxLength.Login)]
    public string Login { get; set; } = null!;
    public DateOnly? Birthday { get; set; }
}
