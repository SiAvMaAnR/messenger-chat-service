using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CSN.Domain.Entities.Accounts;

[Table("Accounts")]
public partial class Account : BaseEntity
{
    public string Email { get; set; } = null!;
    [JsonIgnore]
    public byte[] PasswordHash { get; set; } = null!;
    [JsonIgnore]
    public byte[] PasswordSalt { get; set; } = null!;
}
