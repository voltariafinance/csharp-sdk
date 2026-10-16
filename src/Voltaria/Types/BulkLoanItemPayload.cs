using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record BulkLoanItemPayload : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// How each installment is split into principal and interest: pmt (amortising) or constant_principal (loan amount divided equally across installments, the rest is interest)
    /// </summary>
    [JsonPropertyName("repayment_method")]
    public LoanRepaymentMethodEnum? RepaymentMethod { get; set; }

    /// <summary>
    /// The ID of the client counterparty this loan relates to. It must belong to the loan's client.
    /// </summary>
    [JsonPropertyName("client_counterparty_id")]
    public string? ClientCounterpartyId { get; set; }

    /// <summary>
    /// Additional data related to the loan
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
