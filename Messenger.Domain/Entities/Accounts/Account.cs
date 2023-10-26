using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MessengerX.Domain.Shared.Enums;

namespace MessengerX.Domain.Entities.Accounts;

[Table("Accounts")]
public partial class Account : BaseEntity
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public AccountRole Role { get; } = AccountRole.Public;

    [JsonIgnore]
    public byte[] PasswordHash { get; set; } = null!;

    [JsonIgnore]
    public byte[] PasswordSalt { get; set; } = null!;

    public Account(AccountRole role)
    {
        Role = role;
    }
}
