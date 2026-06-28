using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkRepaymentItemPayload : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The amount of payment made for installment
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// Please provide the repayment_date if it differs from the time you log this repayment. Otherwise, it will be automatically set.
    /// </summary>
    [JsonPropertyName("repayment_date")]
    public DateTime? RepaymentDate { get; set; }

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
    /// ID of the installment to make payment for
    /// </summary>
    [JsonPropertyName("installment_id")]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// ID of the associated loan (alternative to installment_id)
    /// </summary>
    [JsonPropertyName("loan_id")]
    public string? LoanId { get; set; }

    /// <summary>
    /// Correlation ID of associated loan (alternative identifier)
    /// </summary>
    [JsonPropertyName("correlation_id")]
    public string? CorrelationId { get; set; }

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
