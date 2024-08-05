using Messenger.Domain.Specification;

namespace Messenger.Domain.Entities.Messages;

public class MessagesSpec : Specification<Message>
{
    public MessagesSpec(int channelId, string? searchField)
        : base(
            (message) =>
                (message.ChannelId == channelId)
                && (
                    searchField == null
                    || message.Text == null
                    || message.Text.Contains(searchField)
                )
        )
    {
        AddInclude((message) => message.Channel);
        AddInclude((message) => message.Author);
        ApplyOrderByDescending((message) => message.CreatedAt);
    }
}

public class UnreadMessagesSpec : Specification<Message>
{
    public UnreadMessagesSpec(int channelId, int lastMessageId, int accountId)
        : base(
            (message) =>
                message.ChannelId == channelId
                && message.Id <= lastMessageId
                && message.ReadAccounts.All(account => account.Id != accountId)
                && message.AuthorId != accountId
        )
    {
        AddInclude((message) => message.ReadAccounts);
        ApplyTracking();
    }
}

public class MessageSpec : Specification<Message>
{
    public MessageSpec(int channelId, int messageId)
        : base((message) => message.ChannelId == channelId && message.Id == messageId)
    {
        AddInclude((message) => message.Channel);
        AddInclude((message) => message.Author);
    }
}
