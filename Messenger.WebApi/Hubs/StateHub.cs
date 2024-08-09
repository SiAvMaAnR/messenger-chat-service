using Messenger.WebApi.Hubs.Common;
using Messenger.Application.Services.AccountService;
using Messenger.Application.Services.AccountService.Models;
using Messenger.Domain.Shared.Constants.Common;
using Microsoft.AspNetCore.Authorization;

namespace Messenger.WebApi.Hubs;

public class StateHub(IAccountService accountService) : BaseHub, IHub
{
    private readonly IAccountService _accountService = accountService;

    [Authorize]
    public override async Task OnConnectedAsync()
    {
        await _accountService.UpdateStatusAsync(
            new AccountServiceUpdateStatusRequest(AccountStatus.Online)
        );

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _accountService.UpdateStatusAsync(
            new AccountServiceUpdateStatusRequest(AccountStatus.Offline)
        );

        await base.OnDisconnectedAsync(exception);
    }
}
