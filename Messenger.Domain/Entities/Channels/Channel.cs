using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Messages;
using MessengerX.Domain.Shared.Constants.Common;

namespace MessengerX.Domain.Entities.Channels;

[Table("Channels")]
public partial class Channel : BaseEntity
{
    public string? Name { get; set; }
    public string Type { get; set; } = ChannelType.Direct;
    public DateTime LastActivity { get; set; } = DateTime.Now;
    public ICollection<Account> Accounts { get; set; } = [];
    public ICollection<Message> Messages { get; set; } = [];
}
