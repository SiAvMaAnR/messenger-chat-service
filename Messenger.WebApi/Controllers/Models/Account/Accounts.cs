using Messenger.Domain.Shared.Models;

namespace Messenger.WebApi.Controllers.Models.Account;

public class AccountControllerAccountsRequest
{
    public Pagination? Pagination { get; set; }

    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
