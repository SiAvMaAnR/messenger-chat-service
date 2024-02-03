using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MessengerX.Domain.Entities.RefreshTokens;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Accounts;

[Table("Accounts")]
public partial class Account : BaseEntity
{
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; protected set; } = AccountRole.Public;
    public string? Image { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = [];

    [JsonIgnore]
    public byte[] PasswordHash { get; set; } = null!;

    [JsonIgnore]
    public byte[] PasswordSalt { get; set; } = null!;
}
