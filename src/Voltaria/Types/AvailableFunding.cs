using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record AvailableFunding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Currency of the limit
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    [JsonPropertyName("limit")]
    public required string Limit { get; set; }

    [JsonPropertyName("later")]
    public string? Later { get; set; }

    [JsonPropertyName("max_maturity_days")]
    public required int MaxMaturityDays { get; set; }

    [JsonPropertyName("rate")]
    public required string Rate { get; set; }

    [JsonPropertyName("outstanding")]
    public required string Outstanding { get; set; }

    [JsonPropertyName("available")]
    public required string Available { get; set; }

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
