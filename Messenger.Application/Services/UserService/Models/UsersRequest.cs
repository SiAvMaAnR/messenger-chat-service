using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.UserService.Models;

public class UserServiceUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
