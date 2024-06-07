using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Domain.Entities.Messages;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChatServiceMessageAdapter : ChatServiceMessageResponseData
{
    public ChatServiceMessageAdapter(Message message)
    {
        Id = message.Id;
        Text = message.Text;
        ModifiedAt = message.ModifiedAt;
        IsRead = message.IsRead;
        IsDeleted = message.IsDeleted;
        AuthorId = message.AuthorId;
        AuthorLogin = message.Author?.Login;
        ChannelId = message.ChannelId;
    }
}
