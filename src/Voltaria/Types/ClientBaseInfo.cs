using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientBaseInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the client
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The type of the client, must be one of `individual`, `corporate`
    /// </summary>
    [JsonPropertyName("type")]
    public required ClientTypeEnum Type { get; set; }

    /// <summary>
    /// The jurisdiction of the client, must be one of `eu`, `us`, `uk`
    /// </summary>
    [JsonPropertyName("jurisdiction")]
    public required JurisdictionEnum Jurisdiction { get; set; }

    /// <summary>
    /// The company number of the client if type is `corporate`
    /// </summary>
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    /// <summary>
    /// The status of the client. One of the following: `active, rejected, deactivated, pending, pending_onboarding, pre_approved, deleted, inactive`
    /// </summary>
    [JsonPropertyName("status")]
    public required ClientStatusEnum Status { get; set; }

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
