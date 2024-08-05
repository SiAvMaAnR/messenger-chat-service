using System.ComponentModel.DataAnnotations.Schema;
using Messenger.Domain.Entities.Accounts;
using Messenger.Domain.Entities.Channels;

namespace Messenger.Domain.Entities.Messages;

[Table("Messages")]
public partial class Message : BaseEntity, ISoftDelete
{
    public Message(int authorId, int channelId)
    {
        AuthorId = authorId;
        ChannelId = channelId;
    }

    public string? Text { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public bool IsRead { get; private set; } = false;
    public bool IsDeleted { get; private set; } = false;

    [InverseProperty("ReadMessages")]
    public ICollection<Account> ReadAccounts { get; } = [];
    public ICollection<Message> ChildMessages { get; } = [];
    public Account? Author { get; private set; }
    public int AuthorId { get; private set; }
    public Message? TargetMessage { get; set; }
    public int? TargetMessageId { get; set; }
    public Channel? Channel { get; private set; }
    public int ChannelId { get; private set; }
}
