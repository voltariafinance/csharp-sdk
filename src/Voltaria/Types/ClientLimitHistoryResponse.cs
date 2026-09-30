using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientLimitHistoryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the limit record
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// When the limit was granted
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The currency the limit is denominated in
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The credit limit granted to the client
    /// </summary>
    [JsonPropertyName("limit")]
    public required string Limit { get; set; }

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
