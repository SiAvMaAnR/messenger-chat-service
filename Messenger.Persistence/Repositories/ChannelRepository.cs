using MessengerX.Domain.Entities.Channels;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class ChannelRepository : BaseRepository<Channel>, IChannelRepository
{
    public ChannelRepository(EFContext dbContext)
        : base(dbContext) { }
}
