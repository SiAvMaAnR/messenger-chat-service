using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Enums;

namespace MessengerX.Domain.Entities.Administrators;

[Table("Administrators")]
public partial class Administrator : Account
{
    public Administrator()
    {
        Role = AccountRole.Admin;
    }
}
