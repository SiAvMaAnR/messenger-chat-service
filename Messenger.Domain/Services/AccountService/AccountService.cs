using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Exceptions;

namespace MessengerX.Domain.Services;

public class AccountBS : DomainService
{
    public AccountBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Account?> GetAccountByIdAsync(int id, bool isTracking = false)
    {
        return await _unitOfWork.Account.GetAsync(new AccountByIdSpec(id, isTracking));
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return await _unitOfWork.Account.GetAsync(new AccountByEmailSpec(email));
    }

    public async Task UpdateImageAsync(Account account, string? image)
    {
        account.UpdateImage(image);

        _unitOfWork.Account.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateActivityStatusAsync(Account account, string activityStatus)
    {
        account.UpdateActivityStatus(activityStatus);

        _unitOfWork.Account.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Account>> GetAccountsAsync(string? searchField)
    {
        return await _unitOfWork.Account.GetAllAsync(new AccountsSpec(searchField))
            ?? throw new NotExistsException("Accounts");
    }
}
