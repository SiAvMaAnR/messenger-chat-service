using Microsoft.AspNetCore.SignalR;

namespace Messenger.WebApi.Hubs.Common;

public class BaseHub : Hub
{
    protected readonly string _connectionId;

    public BaseHub()
    {
        _connectionId = Context.ConnectionId;
    }
}
