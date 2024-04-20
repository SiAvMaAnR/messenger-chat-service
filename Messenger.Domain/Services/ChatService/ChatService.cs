using MessengerX.Domain.Common;

namespace MessengerX.Domain.Services;

public class ChatBS : DomainService
{
    public ChatBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }
}
