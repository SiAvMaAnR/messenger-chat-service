using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Users;

namespace MessengerX.Domain.Interfaces.UnitOfWork;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
}
