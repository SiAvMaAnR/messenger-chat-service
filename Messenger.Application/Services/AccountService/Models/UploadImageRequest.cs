using Microsoft.AspNetCore.Http;

namespace Messenger.Application.Services.AccountService.Models;

public class AccountServiceUploadImageRequest
{
    public required IFormFile File { get; set; }
}
