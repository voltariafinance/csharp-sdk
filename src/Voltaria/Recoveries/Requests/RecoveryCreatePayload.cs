using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record RecoveryCreatePayload
{
    /// <summary>
    /// The ID of the loan this recovery is associated with.
    /// </summary>
    [JsonPropertyName("loan_id")]
    public required string LoanId { get; set; }

    /// <summary>
    /// The amount recovered (must be &gt; 0).
    /// </summary>
    [JsonPropertyName("amount")]
    public required OneOf<double, string> Amount { get; set; }

    /// <summary>
    /// The currency of the recovered amount, must be one of the supported currencies: eur, gbp, usd, czk, pln, isk
    /// </summary>
    [JsonPropertyName("currency")]
    public required CurrencyEnum Currency { get; set; }

    /// <summary>
    /// The date the recovery was made.
    /// </summary>
    [JsonPropertyName("recovery_date")]
    public required DateOnly RecoveryDate { get; set; }

    /// <summary>
    /// Optional notes about the recovery.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
