using System.ComponentModel.DataAnnotations;
using MessengerX.Domain.Shared.Constants.Validation;

namespace MessengerX.WebApi.Controllers.Models.User;

public class ConfirmationRequest
{
    public string Confirmation { get; set; } = null!;
}
