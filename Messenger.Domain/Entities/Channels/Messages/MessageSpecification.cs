using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Messages;

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
    }
}
