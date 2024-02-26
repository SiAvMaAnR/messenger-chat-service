using MessengerX.Domain.Entities.Messages;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(EFContext dbContext)
        : base(dbContext) { }
}
