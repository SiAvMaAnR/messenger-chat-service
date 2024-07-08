using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceAccountsRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
