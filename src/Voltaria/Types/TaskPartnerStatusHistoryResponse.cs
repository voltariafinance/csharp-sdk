using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

/// <summary>
/// One status change on a task: when it happened, what it moved from and to, and
/// who made it.
/// </summary>
[Serializable]
public record TaskPartnerStatusHistoryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When the status changed.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The status before the change.
    /// </summary>
    [JsonPropertyName("old_status")]
    public TaskStatusEnum? OldStatus { get; set; }

    /// <summary>
    /// The status after the change.
    /// </summary>
    [JsonPropertyName("new_status")]
    public required TaskStatusEnum NewStatus { get; set; }

    /// <summary>
    /// Who made the change. One of the following: partner, support
    /// </summary>
    [JsonPropertyName("actor_type")]
    public required TaskPublicActorTypeEnum ActorType { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
