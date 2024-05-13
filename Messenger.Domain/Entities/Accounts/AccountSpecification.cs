using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Accounts;

public class AccountByIdSpec : Specification<Account>
{
    public AccountByIdSpec(int id)
        : base((account) => account.Id == id)
    {
        ApplyTracking();
    }
}

public class AccountByEmailSpec : Specification<Account>
{
    public AccountByEmailSpec(string email)
        : base((account) => account.Email == email) { }
}
