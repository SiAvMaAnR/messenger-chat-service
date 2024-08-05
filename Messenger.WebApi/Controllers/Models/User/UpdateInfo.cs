using System.ComponentModel.DataAnnotations;
using Messenger.Domain.Shared.Constants.Validation;

namespace Messenger.WebApi.Controllers.Models.User;

public class UserControllerUpdateInfoRequest
{
    [MaxLength(MaxLength.Login)]
    public required string Login { get; set; }
    public DateOnly? Birthday { get; set; }
}
