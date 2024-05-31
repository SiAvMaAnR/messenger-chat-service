using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.ChatService.Models;

public class ChatServiceMessageResponseData
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
}

public class ChatServiceMessagesResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<ChatServiceMessageResponseData>? Messages { get; set; }
}
