using MessengerX.Domain.Specification;

namespace MessengerX.Domain.Entities.Admins;

public class AdminByIdSpec : Specification<Admin>
{
    public AdminByIdSpec(int? id)
        : base((admin) => admin.Id == id) { }
}
