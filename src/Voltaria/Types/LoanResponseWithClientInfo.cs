using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanResponseWithClientInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the loan
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The creation date of the loan
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The last update date of the loan
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the partner
    /// </summary>
    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    /// <summary>
    /// The ID of the client
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The currency of the loan
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The amount of the loan
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// The status of the loan
    /// </summary>
    [JsonPropertyName("status")]
    public required LoanStatusEnum Status { get; set; }

    /// <summary>
    /// The internal rate of return
    /// </summary>
    [JsonPropertyName("irr")]
    public string? Irr { get; set; }

    /// <summary>
    /// The date of the loan
    /// </summary>
    [JsonPropertyName("loan_date")]
    public DateOnly? LoanDate { get; set; }

    /// <summary>
    /// The currency rate conversion to EUR at the time of the loan
    /// </summary>
    [JsonPropertyName("currency_rate")]
    public required string CurrencyRate { get; set; }

    /// <summary>
    /// The correlation ID provided at the creation of the loan
    /// </summary>
    [JsonPropertyName("correlation_id")]
    public string? CorrelationId { get; set; }

    /// <summary>
    /// The payment status of the loan
    /// </summary>
    [JsonPropertyName("payment_status")]
    public LoanPaymentStatusEnum? PaymentStatus { get; set; }

    /// <summary>
    /// The payment reference for the loan
    /// </summary>
    [JsonPropertyName("payment_reference")]
    public string? PaymentReference { get; set; }

    /// <summary>
    /// The date of early settlement if the loan was settled early
    /// </summary>
    [JsonPropertyName("early_settlement_date")]
    public DateOnly? EarlySettlementDate { get; set; }

    /// <summary>
    /// The settlement amount at early settlement if applicable
    /// </summary>
    [JsonPropertyName("early_settlement_amount")]
    public string? EarlySettlementAmount { get; set; }

    /// <summary>
    /// Additional data related to the loan
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// The client details associated with the loan
    /// </summary>
    [JsonPropertyName("client")]
    public required ClientBaseInfo Client { get; set; }

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
