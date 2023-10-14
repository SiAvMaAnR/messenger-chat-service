using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Shared.Enums;

namespace MessengerX.Domain.Entities.Users;

[Table("Users")]
public partial class User : Account
{
    public string Login { get; set; } = null!;
    public string? Image { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public User()
        : base(AccountRole.User) { }
}
