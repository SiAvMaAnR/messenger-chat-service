﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MessengerX.Domain.Entities.Accounts.RefreshTokens;

[Table("RefreshTokens")]
public partial class RefreshToken : BaseEntity
{
    public string Token { get; private set; }
    public DateTime ExpiryTime { get; private set; }
    public int AccountId { get; private set; }
    public Account? Account { get; private set; }
}
