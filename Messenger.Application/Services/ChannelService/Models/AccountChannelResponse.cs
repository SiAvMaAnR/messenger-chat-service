namespace MessengerX.Application.Services.ChannelService.Models;

public class ChannelServiceAccountChannelResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime LastActivity { get; set; }
    public byte[]? Image { get; set; }
    public string? UserActivityStatus { get; set; }
    public DateTime? UserLastOnlineAt { get; set; }
    public int? MembersCount { get; set; }
}
