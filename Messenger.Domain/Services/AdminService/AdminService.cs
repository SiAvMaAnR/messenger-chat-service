using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Admins;

namespace MessengerX.Domain.Services;

public class AdminBS : DomainService
{
    public AdminBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Admin?> GetAdminByIdAsync(int? id)
    {
        return await _unitOfWork.Admin.GetAsync(admin => admin.Id == id);
    }
}
