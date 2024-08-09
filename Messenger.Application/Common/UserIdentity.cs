using System.Security.Claims;
using Messenger.Domain.Exceptions;

namespace Messenger.Application.Common;

public class UserIdentity
{
    public int? Id { get; private set; } = null;
    public ClaimsPrincipal? ClaimsPrincipal { get; private set; }

    public UserIdentity(ClaimsPrincipal? claimsPrincipal)
    {
        Update(claimsPrincipal);
    }

    public void Update(ClaimsPrincipal? claimsPrincipal)
    {
        ClaimsPrincipal =
            claimsPrincipal ?? throw new NotExistsException("ClaimsPrincipal is null", true);

        if (int.TryParse(ClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
        {
            Id = id;
        }
    }
}
