using System.ComponentModel.DataAnnotations;
using Messenger.Domain.Shared.Constants.Validation;

namespace Messenger.WebApi.Controllers.Models.User;

public class UserControllerConfirmationRequest
{
    [MaxLength(MaxLength.Confirmation)]
    public required string Confirmation { get; set; }
}
