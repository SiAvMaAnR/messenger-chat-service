using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Users;

public class UserByIdSpec : Specification<User>
{
    public UserByIdSpec(int? id, bool isTracking)
        : base((user) => user.Id == id)
    {
        if (isTracking)
        {
            ApplyTracking();
        }
    }
}
