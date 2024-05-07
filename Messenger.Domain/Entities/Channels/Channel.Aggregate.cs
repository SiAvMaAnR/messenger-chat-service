using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Shared.Constants.Common;

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

    public Message? GetLastMessage()
    {
        return Messages.LastOrDefault();
    }

    public void UpdateLastActivity(Message message)
    {
        Messages.Add(message);
    }

    public void UpdateImage(string? image)
    {
        if (Type == ChannelType.Private || Type == ChannelType.Public)
        {
            Image = image;
        }
    }
}
