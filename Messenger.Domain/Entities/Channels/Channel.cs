using System.ComponentModel.DataAnnotations.Schema;
using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Messages;

namespace Messenger.Domain.Entities.Channels;

[Table("Channels")]
public partial class Channel : BaseEntity, ISoftDelete
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
    public bool IsDeleted { get; private set; } = false;
}
