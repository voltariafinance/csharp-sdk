using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientLimitResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The currency the limit is denominated in
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The longest loan maturity this limit allows, in days
    /// </summary>
    [JsonPropertyName("max_maturity_days")]
    public required int MaxMaturityDays { get; set; }

    /// <summary>
    /// The credit limit granted to the client
    /// </summary>
    [JsonPropertyName("limit")]
    public required string Limit { get; set; }

    /// <summary>
    /// The rate recorded on this limit
    /// </summary>
    [JsonPropertyName("rate")]
    public required string Rate { get; set; }

    /// <summary>
    /// Principal currently outstanding against this limit
    /// </summary>
    [JsonPropertyName("outstanding")]
    public required string Outstanding { get; set; }

    /// <summary>
    /// Limit minus outstanding. Negative when the client is over limit
    /// </summary>
    [JsonPropertyName("available")]
    public required string Available { get; set; }

    /// <summary>
    /// When the limit was granted
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the limit was last changed
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
