using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels.Messages;

namespace MessengerX.Domain.Entities.Channels;

public partial class Channel : IAggregateRoot
{
    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }

    public void AddAccounts(List<Account> accounts)
    {
        accounts.ForEach(Accounts.Add);
    }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }

    public void UpdateLastActivity(Message message)
    {
        Messages.Add(message);
    }
}
