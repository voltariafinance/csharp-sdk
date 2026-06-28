using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientCreatePayload
{
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
    /// The type of the client, must be one of `individual`,`corporate`. Default is `corporate` if not provided.
    /// </summary>
    [JsonPropertyName("type")]
    public ClientTypeEnum? Type { get; set; }

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
    /// Additional data associated with the client
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
