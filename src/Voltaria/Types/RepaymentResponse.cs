using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record RepaymentResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the repayment log
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The creation date of the repayment log
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ID of the client who made the payment
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The ID of the loan for which the payment was made
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The ID of the installment for which the payment was made
    /// </summary>
    [JsonPropertyName("installment_id")]
    public required string InstallmentId { get; set; }

    /// <summary>
    /// The amount of payment made for installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required string Amount { get; set; }

    /// <summary>
    /// The date of the payment made for installment
    /// </summary>
    [JsonPropertyName("repayment_date")]
    public DateTime? RepaymentDate { get; set; }

    /// <summary>
    /// The type of repayment sent in data field
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Additional metadata related to the repayment
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// Indicates if this repayment is for early settlement
    /// </summary>
    [JsonPropertyName("is_early_settlement")]
    public bool? IsEarlySettlement { get; set; }

    /// <summary>
    /// Principal portion of the repayment, when the partner provides a breakdown of the payment components
    /// </summary>
    [JsonPropertyName("principal_amount")]
    public string? PrincipalAmount { get; set; }

    /// <summary>
    /// Interest portion of the repayment, when the partner provides a breakdown of the payment components
    /// </summary>
    [JsonPropertyName("interest_amount")]
    public string? InterestAmount { get; set; }

    /// <summary>
    /// Late fee portion of the repayment, when the partner provides a breakdown of the payment components
    /// </summary>
    [JsonPropertyName("late_fee_amount")]
    public string? LateFeeAmount { get; set; }

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
