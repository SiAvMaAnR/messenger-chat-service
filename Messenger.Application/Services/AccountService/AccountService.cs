using MessengerX.Application.Services.AccountService.Adapters;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Exceptions;
using MessengerX.Domain.Services;
using MessengerX.Persistence.Extensions;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    private readonly AccountBS _accountBS;

    public AccountService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        AccountBS accountBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _accountBS = accountBS;
    }

    public async Task<AccountServiceUploadImageResponse> UploadImageAsync(
        AccountServiceUploadImageRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync(new AccountByIdSpec(UserId))
            ?? throw new NotExistsException("Account not found");

        string imagePath = _appSettings.FilePath.Image;

        using (var stream = new MemoryStream())
        {
            request.File.CopyTo(stream);
            string? image = await stream.ToArray().WriteToFileAsync(imagePath, account.Email);

            await _accountBS.UpdateImageAsync(account, image);
        }

        return new AccountServiceUploadImageResponse() { IsSuccess = true };
    }

    public async Task<AccountServiceImageResponse> GetImageAsync()
    {
        Account account =
            await _unitOfWork.Account.GetAsync(new AccountByIdSpec(UserId))
            ?? throw new NotExistsException("Account not found");

        byte[]? image = await FileManager.ReadToBytesAsync(account.Image);

        return new AccountServiceImageResponse() { Image = image };
    }

    public async Task<AccountServiceUpdateStatusResponse> UpdateStatusAsync(
        AccountServiceUpdateStatusRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync(new AccountByIdSpec(UserId))
            ?? throw new NotExistsException("Account not found");

        account.UpdateActivityStatus(request.ActivityStatus);

        _unitOfWork.Account.Update(account);
        await _unitOfWork.SaveChangesAsync();

        return new AccountServiceUpdateStatusResponse() { IsSuccess = true };
    }

    public async Task<AccountServiceAccountsResponse> AccountsAsync(
        AccountServiceAccountsRequest request
    )
    {
        IEnumerable<Account> accounts = await _accountBS.GetAccountsAsync();

        PaginatorResponse<Account> paginatedData = accounts
            .OrderBy(account => account.Id)
            .Pagination(request.Pagination);

        var adaptedAccounts = paginatedData
            .Collection
            .Select(account => new AccountServiceAccountAdapter(account))
            .ToList();

        if (request.IsLoadImage)
            await Task.WhenAll(adaptedAccounts.Select(account => account.LoadImageAsync()));

        return new AccountServiceAccountsResponse()
        {
            Meta = paginatedData.Meta,
            Accounts = adaptedAccounts
        };
    }
}
