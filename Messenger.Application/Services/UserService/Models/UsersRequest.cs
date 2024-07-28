using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
