using Microsoft.AspNetCore.Http;

namespace MessengerX.Infrastructure.IPAddressManager;

public class IPAddressManager
{
    private readonly HttpContext? _context;

    public IPAddressManager(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor.HttpContext;
    }

    public string? ClientIP => _context?.Connection.RemoteIpAddress?.ToString();
}
