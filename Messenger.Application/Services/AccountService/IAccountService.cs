using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Application.Services.Common;

namespace MessengerX.Application.Services.AccountService;

public interface IAccountService : IBaseService
{
    Task<AccountServiceUploadImageResponse> UploadImageAsync(
        AccountServiceUploadImageRequest request
    );
    Task<AccountServiceImageResponse> GetImageAsync();
}
