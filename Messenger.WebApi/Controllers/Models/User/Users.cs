using Messenger.Domain.Shared.Models;

namespace Messenger.WebApi.Controllers.Models.Admin;

public class UserControllerUsersRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
}
