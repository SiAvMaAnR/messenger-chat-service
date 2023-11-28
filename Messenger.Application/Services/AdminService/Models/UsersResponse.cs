using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.AdminService.Models;

public class AdminServiceUserResponsePayload
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? Image { get; set; }
    public DateOnly? Birthday { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class AdminServiceUsersResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<AdminServiceUserResponsePayload>? Users { get; set; }
}
