using MessengerX.Domain.Shared.Models;

namespace MessengerX.WebApi.Controllers.Models.Account;

public class AccountControllerAccountsRequest
{
    public Pagination? Pagination { get; set; }

    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
