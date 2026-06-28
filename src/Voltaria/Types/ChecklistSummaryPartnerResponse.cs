using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ChecklistSummaryPartnerResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique checklist summary identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// When the summary was generated.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Checklist type.
    /// </summary>
    [JsonPropertyName("type")]
    public required ChecklistTypeEnum Type { get; set; }

    /// <summary>
    /// AI-generated summary of the checklist.
    /// </summary>
    [JsonPropertyName("ai_description")]
    public string? AiDescription { get; set; }

    /// <summary>
    /// Total number of checklist items.
    /// </summary>
    [JsonPropertyName("total_items")]
    public required int TotalItems { get; set; }

    /// <summary>
    /// Number of completed checklist items.
    /// </summary>
    [JsonPropertyName("completed_items")]
    public required int CompletedItems { get; set; }

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
