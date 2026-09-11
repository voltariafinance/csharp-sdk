using global::System.Text.Json.Serialization;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record EarlySettlementPayload
{
    [JsonIgnore]
    public required string LoanId { get; set; }

    /// <summary>
    /// Date the loan would be settled. Must be today or later. Defaults to today when omitted.
    /// </summary>
    [JsonPropertyName("settlement_date")]
    public DateOnly? SettlementDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
