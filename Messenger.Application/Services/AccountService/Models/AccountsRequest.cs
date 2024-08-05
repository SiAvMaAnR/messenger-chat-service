using Messenger.Domain.Shared.Models;

namespace Messenger.Application.Services.AccountService.Models;

public class AccountServiceAccountsRequest
{
    public Pagination? Pagination { get; set; }
    public bool IsLoadImage { get; set; }
    public string? SearchField { get; set; }
}
