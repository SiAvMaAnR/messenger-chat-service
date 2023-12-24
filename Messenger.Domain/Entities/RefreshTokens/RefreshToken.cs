using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;

namespace MessengerX.Domain.Entities.RefreshTokens;

[Table("RefreshTokens")]
public partial class RefreshToken : BaseEntity
{
    public string Token { get; set; } = null!;
    public DateTime ExpiryTime { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
