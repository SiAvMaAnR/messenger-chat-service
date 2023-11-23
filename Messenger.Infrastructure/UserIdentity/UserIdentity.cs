using System.Security.Claims;
using MessengerX.Domain.Exceptions.BusinessExceptions;

namespace MessengerX.Infrastructure.UserIdentity;

public class UserIdentity
{
    public int Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string Role { get; private set; } = null!;
    public ClaimsPrincipal ClaimsPrincipal { get; private set; } = null!;

    public UserIdentity(ClaimsPrincipal? claimsPrincipal)
    {
        Update(claimsPrincipal);
    }

    public void Update(ClaimsPrincipal? claimsPrincipal)
    {
        ClaimsPrincipal =
            claimsPrincipal ?? throw new NotExistsException("ClaimsPrincipal is null");

        Id = int.Parse(
            ClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotExistsException("ClaimNameIdentifier is null")
        );
        Email =
            ClaimsPrincipal.FindFirst(ClaimTypes.Email)?.Value
            ?? throw new NotExistsException("ClaimEmail is null");
        Role =
            ClaimsPrincipal.FindFirst(ClaimTypes.Role)?.Value
            ?? throw new NotExistsException("ClaimRole is null");
    }
}
