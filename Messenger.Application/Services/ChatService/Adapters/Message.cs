using MessengerX.Application.Services.ChatService.Models;
using MessengerX.Domain.Entities.Messages;

namespace MessengerX.Application.Services.ChatService.Adapters;

public class ChatServiceMessageAdapter : ChatServiceMessageResponseData
{
    public ChatServiceMessageAdapter(Message message)
    {
        Id = message.Id;
        Text = message.Text;
        ModifiedDate = message.ModifiedDate;
        IsRead = message.IsRead;
        IsDeleted = message.IsDeleted;
    }
}
