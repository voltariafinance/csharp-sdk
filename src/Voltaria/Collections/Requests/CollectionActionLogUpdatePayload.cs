using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record CollectionActionLogUpdatePayload
{
    [JsonIgnore]
    public required string LogId { get; set; }

    /// <summary>
    /// The updated status of the action: 'completed' or 'failed'
    /// </summary>
    [JsonPropertyName("status")]
    public required CollectionActionLogUpdatePayloadStatus Status { get; set; }

    /// <summary>
    /// Notes about this action
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
