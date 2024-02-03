using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Users;

[Table("Users")]
public partial class User : Account
{
    public DateOnly? Birthday { get; set; }

    public User()
    {
        Role = AccountRole.User;
    }
}
