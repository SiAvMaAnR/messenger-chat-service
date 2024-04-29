using MessengerX.Domain.Shared.Models;

namespace MessengerX.Application.Services.AdminService.Models;

public class AdminServiceUserResponsePayload
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public bool IsBanned { get; set; }
    public string? ActivityStatus { get; set; }
    public byte[]? Image { get; set; }
    public DateOnly? Birthday { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class AdminServiceUsersResponse
{
    public MetaResponse? Meta { get; set; }
    public IEnumerable<AdminServiceUserResponsePayload>? Users { get; set; }
}
