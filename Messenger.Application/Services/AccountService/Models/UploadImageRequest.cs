using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceUploadImageRequest
{
    public required IFormFile File { get; set; }
}
