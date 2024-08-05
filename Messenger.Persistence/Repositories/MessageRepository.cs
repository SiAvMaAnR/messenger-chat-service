using Messenger.Domain.Entities.Messages;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(EFContext dbContext)
        : base(dbContext) { }
}
