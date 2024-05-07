namespace MessengerX.Domain.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; }
}
