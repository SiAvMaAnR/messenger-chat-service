using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChatService.Models;

public class ChatServiceChannelResponsePayload
{
    public string? Name { get; set; }
    public string Type { get; set; } = null!;
    public DateTime LastActivity { get; set; }
}

public class ChatServiceChannelsResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChatServiceChannelResponsePayload>? Channels { get; set; }
}
