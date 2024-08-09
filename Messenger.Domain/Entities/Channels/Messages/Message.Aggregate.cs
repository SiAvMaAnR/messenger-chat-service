using Messenger.Domain.Entities.Accounts;

namespace Messenger.Domain.Entities.Messages;

public partial class Message : IAggregateRoot
{
    public void AddChildMessage(Message message)
    {
        ChildMessages.Add(message);
    }

    public void AddReadAccounts(Account account)
    {
        ReadAccounts.Add(account);
    }

    public void DeleteMessage()
    {
        IsDeleted = true;
    }

    public void ReadMessage()
    {
        IsRead = true;
    }
}
