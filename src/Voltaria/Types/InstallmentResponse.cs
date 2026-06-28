using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record InstallmentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the installment
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The creation date of the installment
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The last update date of the installment
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The partner ID
    /// </summary>
    [JsonPropertyName("partner_id")]
    public required string PartnerId { get; set; }

    /// <summary>
    /// The client ID
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The currency of the installment
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The status of the installment (possible values: active, overdue, default, sold, restructured, repaid, pending)
    /// </summary>
    [JsonPropertyName("status")]
    public required InstallmentStatusEnum Status { get; set; }

    /// <summary>
    /// The associated loan ID
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The total amount of the installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// The expected repayment date
    /// </summary>
    [JsonPropertyName("expected_repayment_at")]
    public required DateTime ExpectedRepaymentAt { get; set; }

    /// <summary>
    /// The installment number in sequence
    /// </summary>
    [JsonPropertyName("installment_number")]
    public required int InstallmentNumber { get; set; }

    /// <summary>
    /// The total number of installments
    /// </summary>
    [JsonPropertyName("installments")]
    public required int Installments { get; set; }

    /// <summary>
    /// The principal amount of the installment
    /// </summary>
    [JsonPropertyName("principal")]
    public required string Principal { get; set; }

    /// <summary>
    /// The interest amount of the installment
    /// </summary>
    [JsonPropertyName("interest")]
    public required string Interest { get; set; }

    /// <summary>
    /// The amount repaid so far for this installment
    /// </summary>
    [JsonPropertyName("repayment_amount")]
    public string? RepaymentAmount { get; set; }

    /// <summary>
    /// The actual repayment date
    /// </summary>
    [JsonPropertyName("repayment_at")]
    public DateTime? RepaymentAt { get; set; }

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
