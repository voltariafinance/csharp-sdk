using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record CurrencyFieldSpec : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Fields that must be provided for this currency.
    /// </summary>
    [JsonPropertyName("required")]
    public IEnumerable<string> Required { get; set; } = new List<string>();

    /// <summary>
    /// Fields that are accepted but not required.
    /// </summary>
    [JsonPropertyName("optional")]
    public IEnumerable<string>? Optional { get; set; }

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
