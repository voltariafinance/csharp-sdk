using global::System.Text.Json.Serialization;
using OneOf;
using Voltaria.Core;

namespace Voltaria;

[Serializable]
public record LoanDefaultPayload
{
    [JsonIgnore]
    public required string LoanId { get; set; }

    /// <summary>
    /// Date the loan is marked as defaulted.
    /// </summary>
    [JsonPropertyName("default_date")]
    public required DateOnly DefaultDate { get; set; }

    /// <summary>
    /// Amount recovered when the defaulted loan is sold.
    /// </summary>
    [JsonPropertyName("sold_amount")]
    public required OneOf<double, string> SoldAmount { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
