using MessengerX.Domain.Entities.Admins;
using MessengerX.Persistence.DBContext;
using MessengerX.Persistence.Repositories.Common;

namespace MessengerX.Persistence.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(EFContext dbContext)
        : base(dbContext) { }
}
