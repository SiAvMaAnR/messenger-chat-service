using Messenger.Domain.Entities.Admins;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(EFContext dbContext)
        : base(dbContext) { }
}
