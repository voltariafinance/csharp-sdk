using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanCreatePayload
{
    /// <summary>
    /// The ID of the client for this loan
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The currency of the loan, must be one of the supported currencies: eur, gbp, usd, czk, pln, isk
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The amount of the loan
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// The correlation ID you provided at the creation of the loan
    /// </summary>
    [JsonPropertyName("correlation_id")]
    public string? CorrelationId { get; set; }

    /// <summary>
    /// Please provide the loan_date if it differs from the loan creation time (created_at). Otherwise, it will be automatically set.
    /// </summary>
    [JsonPropertyName("loan_date")]
    public DateOnly? LoanDate { get; set; }

    /// <summary>
    /// List of installments for the loan, each with a due date and amount
    /// </summary>
    [JsonPropertyName("installments")]
    public IEnumerable<LoanInstallmentCreatePayload> Installments { get; set; } =
        new List<LoanInstallmentCreatePayload>();

    /// <summary>
    /// Additional data related to the loan
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
