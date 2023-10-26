using MessengerX.Application.Services.Common;
using MessengerX.Application.Services.AccountService.Models;
using MessengerX.Domain.Interfaces.UnitOfWork;
using MessengerX.Domain.Exceptions.ApiExceptions;
using MessengerX.Infrastructure.AuthOptions;
using MessengerX.Domain.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MessengerX.Application.Services.AccountService;

public class AccountService : BaseService, IAccountService
{
    public AccountService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IConfiguration configuration
    )
        : base(unitOfWork, context, configuration) { }

    public Task<GetAllAccountsResponse> GetAllAsync(GetAllAccountsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginAccountResponse> LoginAsync(LoginAccountRequest request)
    {
        var account =
            await _unitOfWork.Account.GetAsync(account => account.Email == request.Email)
            ?? throw new NotFoundException("Account not found");

        bool isVerify = PasswordOptions.VerifyPasswordHash(
            request.Password,
            new Password() { Hash = account.PasswordHash, Salt = account.PasswordSalt }
        );

        if (!isVerify)
            throw new BadRequestException("Incorrect email or password");

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Name, account.Login),
            new(ClaimTypes.Email, account.Email),
            new(ClaimTypes.Role, account.Role.ToString())
        };

        string secretKey =
            _configuration["Authorization:SecretKey"]
            ?? throw new BadRequestException("Missing authorization secretKey");

        string audience =
            _configuration["Authorization:Audience"]
            ?? throw new BadRequestException("Missing authorization audience");

        string issuer =
            _configuration["Authorization:Issuer"]
            ?? throw new BadRequestException("Missing authorization issuer");

        string lifeTime =
            _configuration["Authorization:LifeTime"]
            ?? throw new BadRequestException("Missing authorization lifeTime");

        var tokenParams = new Dictionary<string, string>()
        {
            { "secretKey", secretKey },
            { "audience", audience },
            { "issuer", issuer },
            { "lifeTime", lifeTime },
        };

        string token = TokenOptions.CreateToken(claims, tokenParams);

        return new LoginAccountResponse() { TokenType = "Bearer", Token = token };
    }
}
