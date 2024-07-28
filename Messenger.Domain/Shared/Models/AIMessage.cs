using System.Text.Json.Serialization;

namespace MessengerX.Domain.Shared.Models;

public class AIMessage
{
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }
}
