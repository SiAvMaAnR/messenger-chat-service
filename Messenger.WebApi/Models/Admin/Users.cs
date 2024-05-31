using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Admin;

public class AdminControllerUsersRequest
{
    public Pagination? Pagination { get; set; }

    public bool IsLoadImage { get; set; }
}
