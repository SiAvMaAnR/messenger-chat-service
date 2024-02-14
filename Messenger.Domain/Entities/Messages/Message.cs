using System.ComponentModel.DataAnnotations.Schema;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Entities.Channels;

namespace MessengerX.Domain.Entities.Messages;

[Table("Messages")]
public partial class Message : BaseEntity
{
    public string? Text { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsRead { get; set; } = false;
    public bool IsDelete { get; set; } = false;
    [InverseProperty("ReadMessages")]
    public ICollection<Account> ReadAccounts { get; set; } = [];
    public ICollection<Message> ChildMessages { get; set; } = [];
    public Account Author { get; set; } = null!;
    public int AuthorId { get; set; }
    public Message? TargetMessage { get; set; }
    public int? TargetMessageId { get; set; }
    public Channel Channel { get; set; } = null!;
    public int ChannelId { get; set; }
}
