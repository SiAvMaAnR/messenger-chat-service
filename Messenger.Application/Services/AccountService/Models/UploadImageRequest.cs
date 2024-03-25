using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.AccountService.Models;

public class AccountServiceUploadImageRequest
{
    

    public IFormFile File { get; set; } = null!;
}
