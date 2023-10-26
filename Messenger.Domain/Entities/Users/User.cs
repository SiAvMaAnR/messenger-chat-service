using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Enums;

namespace MessengerX.Domain.Entities.Users;

[Table("Users")]
public partial class User : Account
{
    public string? Image { get; set; }
    public DateOnly? DateOfBirth { get; set; }

    public User()
        : base(AccountRole.User) { }
}
