using CSN.Domain.Entities.Accounts;

namespace CSN.Domain.Interfaces.UnitOfWork;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
}
