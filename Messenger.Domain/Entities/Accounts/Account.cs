﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Messenger.Domain.Entities.Channels;
using Messenger.Domain.Entities.Messages;
using Messenger.Domain.Entities.RefreshTokens;
using Messenger.Domain.Shared.Constants.Common;

namespace Messenger.Domain.Entities.Accounts;

[Table("Accounts")]
public partial class Account : BaseEntity
{
    public Account(string email, string login, byte[] passwordHash, byte[] passwordSalt)
    {
        Email = email;
        Login = login;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public string Login { get; private set; }
    public string Email { get; private set; }
    public string Role { get; protected set; } = AccountRole.Public;
    public string? Image { get; set; }
    public string ActivityStatus { get; set; } = AccountStatus.Offline;
    public DateTime LastOnlineAt { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; private set; } = [];

    [JsonIgnore]
    public byte[] PasswordHash { get; private set; }

    [JsonIgnore]
    public byte[] PasswordSalt { get; private set; }
    public ICollection<Channel> Channels { get; set; } = [];

    [InverseProperty("ReadAccounts")]
    public ICollection<Message> ReadMessages { get; private set; } = [];

    [InverseProperty("Author")]
    public ICollection<Message> Messages { get; private set; } = [];
}
