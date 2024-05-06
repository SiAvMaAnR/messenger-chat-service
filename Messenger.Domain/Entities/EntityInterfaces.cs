namespace MessengerX.Domain.Entities;

public interface ISoftDeleted
{
    bool IsDeleted { get; }
}
