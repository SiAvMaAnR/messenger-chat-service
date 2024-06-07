﻿using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Accounts;

public class AccountByIdSpec : Specification<Account>
{
    public AccountByIdSpec(int id, bool isTracking)
        : base((account) => account.Id == id)
    {
        if (isTracking)
        {
            ApplyTracking();
        }
    }
}

public class AccountsByIdsSpec : Specification<Account>
{
    public AccountsByIdsSpec(IEnumerable<int> ids)
        : base((account) => ids.Contains(account.Id))
    {
        ApplyTracking();
    }
}

public class AccountByEmailSpec : Specification<Account>
{
    public AccountByEmailSpec(string email)
        : base((account) => account.Email == email) { }
}

public class AccountsSpec : Specification<Account>
{
    public AccountsSpec(string? searchField)
        : base((account) => searchField == null || account.Login.Contains(searchField))
    {
        ApplyOrderBy(account => account.Id);
    }
}
