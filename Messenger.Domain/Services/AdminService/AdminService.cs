using Messenger.Domain.Common;
using Messenger.Domain.Entities.Admins;

namespace Messenger.Domain.Services;

public class AdminBS : DomainService
{
    public AdminBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Admin?> GetAdminByIdAsync(int? id)
    {
        return await _unitOfWork.Admin.GetAsync(new AdminByIdSpec(id));
    }
}
