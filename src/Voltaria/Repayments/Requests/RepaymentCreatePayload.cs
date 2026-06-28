using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record RepaymentCreatePayload
{
    /// <summary>
    /// ID of the installment
    /// </summary>
    [JsonIgnore]
    public string? InstallmentId { get; set; }

    /// <summary>
    /// ID of the associated Loan
    /// </summary>
    [JsonIgnore]
    public string? LoanId { get; set; }

    /// <summary>
    /// Correlation ID of associated loan
    /// </summary>
    [JsonIgnore]
    public string? CorrelationId { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
