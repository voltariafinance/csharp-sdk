using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record ClientCounterpartyUpdatePayload
{
    [JsonIgnore]
    public required string ClientId { get; set; }

    [JsonIgnore]
    public required string CounterpartyId { get; set; }

    /// <summary>
    /// The counterparty's legal or trading name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 code of the country the counterparty is registered in
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// The counterparty's company registration number
    /// </summary>
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    /// <summary>
    /// Free-text notes about the counterparty
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
