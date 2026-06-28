using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the client
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The creation date of the client
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The last update date of the client
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The correlation ID you provided at the creation of the client
    /// </summary>
    [JsonPropertyName("correlation_id")]
    public string? CorrelationId { get; set; }

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

    /// <summary>
    /// The limits associated with the client
    /// </summary>
    [JsonPropertyName("limits")]
    public IEnumerable<ClientLimitResponse>? Limits { get; set; }

    /// <summary>
    /// Additional data associated with the client
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

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
