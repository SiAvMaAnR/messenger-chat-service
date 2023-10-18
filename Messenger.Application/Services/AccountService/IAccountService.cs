using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.AccountService.Models;

namespace MessengerX.Application.Services.AccountService;

public interface IAccountService : IBaseService
{
    Task<GetAllAccountsResponse> GetAllAsync(GetAllAccountsRequest request);
}
