using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.UserService.Models;

public class UserServiceUploadImageRequest
{
    public IFormFile File { get; set; } = null!;
}
