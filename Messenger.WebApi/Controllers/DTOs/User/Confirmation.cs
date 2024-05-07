using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.User;

public class UserControllerConfirmationRequest
{
    [MaxLength(MaxLength.Confirmation)]
    public required string Confirmation { get; set; }
}
