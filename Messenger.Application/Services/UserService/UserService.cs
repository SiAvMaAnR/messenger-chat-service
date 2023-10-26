using System.Text.Json;
using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.UserService.Models;
using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Shared.Models;
using MessengerX.Notifications;
using MessengerX.Notifications.Common;
using MessengerX.Notifications.Email.Handlers;
using MessengerX.Notifications.Email.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MessengerX.Application.Services.UserService;

public class UserService : BaseService, IUserService
{
    private readonly IDataProtectionProvider _protection;
    private readonly INotificationClient _emailClient;

    public UserService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IConfiguration configuration,
        IDataProtectionProvider protection
    )
        : base(unitOfWork, context, configuration)
    {
        _protection = protection;

        //ПЕРЕДАТЬ ЧЕРЕЗ api level

        var smtpModel = new Smtp()
        {
            Email =
                _configuration["Smtp:Email"] ?? throw new BadRequestException("Missing smtp email"),
            Password =
                _configuration["Smtp:Password"]
                ?? throw new BadRequestException("Missing smtp password"),
            Host =
                _configuration["Smtp:Host"] ?? throw new BadRequestException("Missing smtp host"),
            Port = int.Parse(
                _configuration["Smtp:Port"] ?? throw new BadRequestException("Missing smtp port")
            ),
        };

        _emailClient = new EmailClient(new MessageHandler(smtpModel));
    }

    public Task<GetAllUsersResponse> GetAllAsync(GetAllUsersRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<RegistrationUserResponse> RegistrationAsync(RegistrationUserRequest request)
    {
        if (await _unitOfWork.User.AnyAsync(user => user.Email == request.Email))
            throw new BadRequestException("Account already exists");

        string baseUrl =
            _configuration["Client:BaseUrl"]
            ?? throw new BadRequestException("Missing client baseUrl");

        string path =
            _configuration["Confirmation:Path"]
            ?? throw new BadRequestException("Missing confirmation path");

        string secretKey =
            _configuration["Confirmation:SecretKey"]
            ?? throw new BadRequestException("Missing confirmation secretKey");

        IDataProtector protector = _protection.CreateProtector(secretKey);

        string confirmationJson = JsonSerializer.Serialize(
            new Confirmation()
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth
            }
        );

        string confirmation = protector.Protect(confirmationJson);

        string link = $"{baseUrl}/{path}?code={confirmation}";

        string smtpEmail =
            _configuration["Smtp:Email"] ?? throw new BadRequestException("Missing smtp email");

        var messageModel = new Message()
        {
            From = new Address(baseUrl, smtpEmail),
            To = new Address(request.Login, request.Email),
            Subject = $"Welcome, verify your account. To do this, follow the link!",
            Content = link
        };

        await _emailClient.SendAsync(messageModel);

        return new RegistrationUserResponse() { IsSuccess = true };
    }

    public Task<ConfirmationUserResponse> ConfirmationAsync(ConfirmationUserRequest request)
    {
        throw new NotImplementedException();
    }
}
