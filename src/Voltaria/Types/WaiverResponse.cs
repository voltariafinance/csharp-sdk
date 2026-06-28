using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record WaiverResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the waiver
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the client associated with the waiver
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The ID of the loan associated with the waiver
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// The ID of the limit request associated with the waiver
    /// </summary>
    [JsonPropertyName("limit_request_id")]
    public string? LimitRequestId { get; set; }

    /// <summary>
    /// The status of the waiver. One of: pending, active, paid, rejected
    /// </summary>
    [JsonPropertyName("status")]
    public required WaiverStatusEnum Status { get; set; }

    /// <summary>
    /// The date of the waiver
    /// </summary>
    [JsonPropertyName("waiver_date")]
    public required DateOnly WaiverDate { get; set; }

    /// <summary>
    /// The currency of the waiver amount
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The waiver amount
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// Additional notes about the waiver
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// The timestamp when the waiver was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

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
