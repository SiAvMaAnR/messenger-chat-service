using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Users;

public class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(int? id)
        : base((user) => user.Id == id) { }
}
