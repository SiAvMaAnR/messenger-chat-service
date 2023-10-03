using System.ComponentModel.DataAnnotations.Schema;
using CSN.Domain.Entities.Accounts;

namespace CSN.Domain.Entities.Users;

[Table("Users")]
public partial class User : Account
{
    public string Login { get; set; } = null!;
    public string? Image { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
