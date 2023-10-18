using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    public AccountService(IUnitOfWork unitOfWork, IHttpContextAccessor context)
        : base(unitOfWork, context) { }

    public Task<GetAllAccountsResponse> GetAllAsync(GetAllAccountsRequest request)
    {
        throw new NotImplementedException();
    }
}
