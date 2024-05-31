using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Exceptions;

namespace MessengerX.Domain.Services;

public class ChatBS : DomainService
{
    public ChatBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<IEnumerable<Message>> MessagesAsync(
        int channelId,
        string? searchField
    )
    {
        IEnumerable<Message>? messages = await _unitOfWork
            .Message
            .GetAllAsync(new MessagesSpec(channelId, searchField));

        if (messages == null)
            throw new NotExistsException("Messages not exists");

        return messages;
    }
}
