using Messenger.Domain.Entities.Channels;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class ChannelRepository : BaseRepository<Channel>, IChannelRepository
{
    public ChannelRepository(EFContext dbContext)
        : base(dbContext) { }
}
