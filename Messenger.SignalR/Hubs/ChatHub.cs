using Messenger.SignalR.Hubs.Common;
using Microsoft.AspNetCore.Authorization;

namespace Messenger.SignalR.Hubs;

public class ChatHub : BaseHub, IHub
{
    [Authorize]
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }


    public async Task SendMessageAsync()
    {

    }
}
