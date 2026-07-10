using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record CollectionActionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the collection action
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the collection action
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The channel used for this action
    /// </summary>
    [JsonPropertyName("action_type")]
    public required CollectionActionTypeEnum ActionType { get; set; }

    /// <summary>
    /// Whether this action is currently active
    /// </summary>
    [JsonPropertyName("is_active")]
    public required bool IsActive { get; set; }

    /// <summary>
    /// A description of the collection action
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Timing offset relative to the installment due date, e.g. 'd-5' (5 days before) or 'd+3' (3 days after)
    /// </summary>
    [JsonPropertyName("timing")]
    public required string Timing { get; set; }

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
