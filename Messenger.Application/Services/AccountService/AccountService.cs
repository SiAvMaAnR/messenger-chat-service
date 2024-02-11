using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Entities.Accounts;
using MessengerX.Domain.Exceptions.BusinessExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Infrastructure.AppSettings;
using MessengerX.Notifications.Email;
using MessengerX.Persistence.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    private readonly IDataProtectionProvider _protection;
    private readonly IEmailClient _emailClient;

    public AccountService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        IDataProtectionProvider protection,
        IEmailClient emailClient
    )
        : base(unitOfWork, context, appSettings)
    {
        _protection = protection;
        _emailClient = emailClient;
    }

    public async Task<AccountServiceUploadImageResponse> UploadImageAsync(
        AccountServiceUploadImageRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync((account) => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        string imagePath = _appSettings.FilePath.Image;

        using (var stream = new MemoryStream())
        {
            request.File.CopyTo(stream);
            string? image = await stream.ToArray().WriteToFileAsync(imagePath, account.Email);
            account.UpdateImage(image);
        }
        await _unitOfWork.Account.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();

        return new AccountServiceUploadImageResponse() { IsSuccess = true };
    }

    public async Task<AccountServiceImageResponse> GetImageAsync()
    {
        Account account =
            await _unitOfWork.Account.GetAsync((account) => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        byte[]? image = await FileManager.ReadToBytesAsync(account.Image);

        return new AccountServiceImageResponse() { Image = image };
    }

    public async Task<AccountServiceUpdateStatusResponse> UpdateStatusAsync(
        AccountServiceUpdateStatusRequest request
    )
    {
        Account account =
            await _unitOfWork.Account.GetAsync((account) => account.Id == _userIdentity.Id)
            ?? throw new NotExistsException("Account not found");

        account.UpdateActivityStatus(request.ActivityStatus);

        await _unitOfWork.Account.UpdateAsync(account);
        await _unitOfWork.SaveChangesAsync();

        return new AccountServiceUpdateStatusResponse() { IsSuccess = true };
    }
}
