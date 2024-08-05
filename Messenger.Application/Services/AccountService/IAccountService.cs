using Messenger.Application.Services.AccountService.Models;
using Messenger.Application.Services.Common;

namespace Messenger.Application.Services.AccountService;

public interface IAccountService : IBaseService
{
    Task<AccountServiceUpdateStatusResponse> UpdateStatusAsync(
        AccountServiceUpdateStatusRequest request
    );
    Task<AccountServiceUploadImageResponse> UploadImageAsync(
        AccountServiceUploadImageRequest request
    );
    Task<AccountServiceImageResponse> GetImageAsync();
    Task<AccountServiceAccountsResponse> AccountsAsync(AccountServiceAccountsRequest request);
    Task<AccountServiceProfileResponse> GetProfileAsync();
    Task<AccountServiceAccountImageResponse> GetAccountImageAsync(
        AccountServiceAccountImageRequest request
    );
}
