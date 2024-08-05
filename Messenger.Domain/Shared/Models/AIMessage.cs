using System.Text.Json.Serialization;

namespace Messenger.Domain.Shared.Models;

public class AIMessage
{
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }
}
