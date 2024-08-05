namespace Messenger.Application.Services.AccountService.Models;

public class AccountServiceUpdateStatusRequest(string activityStatus)
{
    public string ActivityStatus { get; set; } = activityStatus;
}
