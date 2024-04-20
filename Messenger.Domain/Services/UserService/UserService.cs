using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Users;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Exceptions.Common;
using MessengerX.Domain.Shared.Models;

namespace MessengerX.Domain.Services;

public class UserBS : DomainService
{
    public UserBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<User?> GetUserByIdAsync(int? id)
    {
        return await _unitOfWork.User.GetAsync(user => user.Id == id);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _unitOfWork.User.GetAllAsync()
            ?? throw new NotExistsException("Users not exists");
    }

    public async Task CheckExistenceByEmailAsync(string email)
    {
        if (await _unitOfWork.Account.AnyAsync(account => account.Email == email))
        {
            throw new AlreadyExistsException(
                "Account already exists",
                "Account with this email already exists"
            );
        }
    }

    public async Task BlockUserAsync(User user)
    {
        user.UpdateIsBanned(true);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UnblockUserAsync(User user)
    {
        user.UpdateIsBanned(false);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ConfirmRegistrationAsync(Confirmation confirmation)
    {
        if (confirmation.ExpirationDate < DateTime.Now)
            throw new ExpiredException("Confirmation has expired", ClientMessageSettings.Same);

        if (await _unitOfWork.Account.AnyAsync(account => account.Email == confirmation.Email))
            throw new AlreadyExistsException("Account already exists", ClientMessageSettings.Same);

        Password password = AuthBS.CreatePasswordHash(confirmation.Password);

        var user = new User(confirmation.Email, confirmation.Login, password.Hash, password.Salt)
        {
            Birthday = confirmation.Birthday,
        };

        await _unitOfWork.User.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user, string login, DateOnly? birthday)
    {
        user.UpdateLogin(login);
        user.UpdateBirthday(birthday);

        await _unitOfWork.User.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
