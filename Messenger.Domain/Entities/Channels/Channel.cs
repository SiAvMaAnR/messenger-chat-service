using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels.Messages;

namespace MessengerX.Domain.Entities.Channels;

[Table("Channels")]
public partial class Channel : BaseEntity
{
    public Channel(string type)
    {
        Type = type;
    }
    public string? Name { get; set; }
    public string Type { get; private set; }
    public DateTime LastActivity { get; private set; } = DateTime.Now;
    public ICollection<Account> Accounts { get; private set; } = [];
    public ICollection<Message> Messages { get; private set; } = [];
    public string? Image { get; set; }
}
