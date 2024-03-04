using MessengerX.Domain.Interfaces.Repository;

namespace MessengerX.Domain.Entities.Messages;

public interface IMessageRepository : IAsyncRepository<Message> { }
